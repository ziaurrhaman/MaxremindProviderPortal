// Your web app's Firebase configuration
var firebaseConfig = {
    apiKey: "AIzaSyCiWHht_8XivuXibJqzdqWjJ1cUdxp3_CI",
    authDomain: "testportalchatapp.firebaseapp.com",
    databaseURL: "https://testportalchatapp.firebaseio.com",
    projectId: "testportalchatapp",
    storageBucket: "testportalchatapp.appspot.com",
    messagingSenderId: "426029568072",
    appId: "1:426029568072:web:8ef8645412ea744917c87d"
};
// Initialize Firebase
firebase.initializeApp(firebaseConfig);

const messaging = firebase.messaging();
var database = firebase.database();
var presenceRef = null;

messaging.usePublicVapidKey("BIquWfQtdPbjWDjVUvbIah_Jh35GnUcjFCice3FTkc2-QMN7S6Js4Gq2bEOt7LjCQueRxUy0tCtgeaAC2JGJVvY");

navigator.serviceWorker.register('js/firebase-messaging-sw.js')
    .then((registration) => {
        console.log('serviceworker registered');
        messaging.useServiceWorker(registration);
    });

messaging.onMessage(function (payload) {
    console.log(payload);
    //if (payload.data.senderid == Selected.userId) {
    //    let messagelist = $('#messagelist').html();
    //    messagelist += `<li id="to" class="row py-1 w-100 no-gutters">
    //                        <div class="col-6 p-1 bg-primary text-white shadow rounded overflow-hidden">${payload.data.message}</div>
    //                    </li>`;
    //    $('#messagelist').html(messagelist);
    //}
});

//globals//

var Selected = null;


//globals//

$('#LoginButton').click(function (e) {
    let username = $('#LoginUserName').val();
    let password = $('#LoginPassword').val();
    if (username == "" || password == "") alert('fill username and password');
    else {
        if (!$(this).hasClass('disabled'));
        LoginAndGetToken(username, password);
    }
})

$('#SignUpButton').click(async function (e) {
    let username = $('#SinUpUserName').val();
    let email = $('#SinUpEmail').val();
    let password = $('#SignUpPassword').val();
    let cpassword = $('#SignUpCPassword').val();
    if (username == "" || password == "") {
        alert('fill all fields');
    } else {
        if (password != cpassword) {
            alert("password does not match");
        } else {
            try {
                const auth = await firebase.auth().createUserWithEmailAndPassword(email, password);
                alert('signup successfull');
                writeUserData(auth.user.uid, username, email, '');
                LoginAndGetToken(username, password);
            } catch (error) {
                console.log(error);
            }
        }
    }
});
$('#logout-link').click(function (e) {
    e.preventDefault();
    if (!$(this).hasClass('disabled')) {
        $(this).addClass('disabled');
        $('#login-link').removeClass('disabled');
    }
})

async function LoginAndGetToken(username, password) {
    try {
        
        var uid = (await firebase.auth().signInWithEmailAndPassword(username, password)).user;
        var User = (await database.ref('users/' + (uid.uid)).once('value')).val();
        alert('user logged in');
        $('#login-link').addClass('disabled');
        $('#logout-link').removeClass('disabled');
        // handler for updates
        var commentsRef = database.ref('message_list/');
        commentsRef.on('child_added', function (data) {
            var messages = data.val();
            if (Selected != null) {
               var messagelist = $('#messagelist').html();
                if ((messages.toid == Selected.userId &&
                    messages.fromid == firebase.auth().currentUser.uid)
                    ||
                    (messages.fromid == Selected.userId &&
                        messages.toid == firebase.auth().currentUser.uid)
                ) {
                    if (messages.fromid == Selected.userId) {
                        messagelist += `<li id="to" class="row py-1 w-100 no-gutters">
                            <div class="col-6 p-1 bg-primary text-white shadow rounded overflow-hidden">${messages.text}</div>
                        </li>`;
                    } else {
                        messagelist += `<li class="row py-1 w-100 no-gutters justify-content-end">
                            <div class="col-6  bg-white p-1  shadow rounded overflow-hidden">${messages.text}</div>
                        </li>`;
                    }
                }
                $('#messagelist').html(messagelist);
            }
        });

        var userRef = database.ref('users/');
        userRef.on('child_changed', function (user) {
            debugger;
            let pdata = user.val();
            let html = $('#userlist').html();
                let email = pdata.email;
                let status = (pdata.LoggedIn) ? 'online' : 'offline';
                if (email != User.email) {
                    html += `<li class="p-1 w-100 text-white" onclick="SetSelected('${pdata.userId}')">
                <div class="row no-gutters w-100">
                    <div class="col-2"><img class="img-fluid w-100" /></div>
                    <div class="col-10"><span>${pdata.username}</span><sub>${status}<sub></div>
                </div>
            </li>`;
                }
            $('#userlist').html(html);
        });




        // handler for updates
        //var auth = firebase.auth().currentUser;
        presenceRef = await database.ref('/users/' + (uid.uid) + '/LoggedIn');
        presenceRef.onDisconnect().set(false);
        debugger;
        var users = await database.ref('/users/').once('value');
        console.log(users);
        messaging.getToken().then((currentToken) => {
            if (currentToken) {
                //writeUserData('', 'Asad Mehmood', userdata.email, '');
                updateUserData(User.userId, User.username, User.email, currentToken,true);
                let html = "";
                let pdata = users.val();
                for (let data in pdata) {
                    let email = pdata[data].email
                    let status = (pdata[data].LoggedIn) ? 'online' : 'offline';
                    if (email != User.email) {
                        html += `<li class="p-1 w-100 text-white" onclick="SetSelected('${pdata[data].userId}')">
                <div class="row no-gutters w-100">
                    <div class="col-2"><img class="img-fluid w-100" /></div>
                    <div class="col-10"><span>${pdata[data].username}</span><sub>${status}<sub></div>
                </div>
            </li>`;
                    }
                }
                $('#userlist').html(html);

            } else {
                console.log('No Instance ID token available. Request permission to generate one.');
            }
        }).catch((err) => {
            console.log('An error occurred while retrieving token. ', err);
        })
    } catch (error) {
        console.log(error);
    }
}



firebase.auth().onAuthStateChanged(function (user) {
    if (user) {
        var email = user.email;
        var uid = user.uid;
    } else {
        // User is signed out.
        // ...
    }
});


function writeUserData(userId, name, email, Token) {
    database.ref('users/' + userId).set({
        username: name,
        userId: userId,
        email: email,
        token: Token,
        LoggedIn:false
    });

}

function updateUserData(userId, name, email, Token,IsLoggedIn) {
  
    var postData = {
        email: email,
        userId: userId,
        token: Token,
        username: name,
        LoggedIn: IsLoggedIn
    };


    var updates = {};
    updates['/users/' + userId] = postData;
    return database.ref().update(updates);
}


async function SetSelected(userid) {
    var user = await database.ref('/users/' + userid).once('value');
    Selected = user.val();
    if (Selected != null) {
        $('#selectedlist').html(
            `<li class="p-1 w-100 text-white">
                <div class="row no-gutters w-100">
                    <div class="col-2"><img class="img-fluid w-100" /></div>
                    <div class="col-10"><span>${Selected.username}</span></div>
                </div>
            </li>`);
        var messages = (await database.ref('/message_list/').once('value')).val();
        let messagelist = "";
        for (let data in messages) {
            if ((messages[data].toid == Selected.userId && 
                messages[data].fromid == firebase.auth().currentUser.uid)
                ||
                (messages[data].fromid == Selected.userId &&
                messages[data].toid == firebase.auth().currentUser.uid)
            ) {
                if (messages[data].fromid == Selected.userId) {
                    messagelist += `<li id="to" class="row py-1 w-100 no-gutters">
                            <div class="col-6 p-1 bg-primary text-white shadow rounded overflow-hidden">${messages[data].text}</div>
                        </li>`;
                } else {
                    messagelist += `<li class="row py-1 w-100 no-gutters justify-content-end">
                            <div class="col-6  bg-white p-1  shadow rounded overflow-hidden">${messages[data].text}</div>
                        </li>`;
                }
            }
        }
        $('#messagelist').html(messagelist);
    }
}




$('#send').click(function (e) {
    if (Selected == null)
        alert('Select the user from right list');
    else {
        let message = $('#message').val();
        SendMessage(message, Selected.token);
    }
})

async function SendMessage(message, user) {
    var current = firebase.auth().currentUser;
    
    var Obj2Send = {};
    //if (user == undefined) {
    //    Obj2Send.to = '';
    //    var snapshot = await database.ref('/users/').once('value');
           
    //    let pdata = snapshot.val();
    //    let ok = [];
    //    for (let data in pdata) {
    //            let email = pdata[data].emial
    //            if (email != current.email) {
    //                ok.push(pdata[data].token);
    //            }
    //    }
    //    Obj2Send.to = ok.join(',');
    //        console.log(ok);
    //} else {
    //    database.ref('/users/' + user).once('value').then(function (snapshot) {

    //        Obj2Send.to = snapshot.val().token;
    //    });
    //}
    Obj2Send.to = user;
    Obj2Send.data = {};
    Obj2Send.data.message = message;
    Obj2Send.data.senderid = firebase.auth().currentUser.uid;
    let http = new XMLHttpRequest();
    http.open('post', 'https://fcm.googleapis.com/fcm/send', true);
    http.setRequestHeader('Content-Type', 'application/json');
    http.setRequestHeader('Authorization', 'key=AAAAYzFXUEg:APA91bEwWrPJh0JJb4g8pIhWeRuAI0kpY6CJ_VxR9XR3SZ9sQIKteheUdlrSPa0a8vh4D7yPW8djvTl1Gu2GfZydVnTxNz91idiFc8MznScTJ2HhBX5kaa75AhMxWjin-6iVCzX3zlMt');
    http.onreadystatechange = function (stat) {
        if (http.readyState == 4) {
            console.log(JSON.parse(http.responseText));
            var messageListRef = database.ref('message_list/');
            var newMessageRef = messageListRef.push();
            var key = newMessageRef.key;
            console.log(key);
            newMessageRef.set({
                messagekey: key,
                fromid: firebase.auth().currentUser.uid,
                toid: Selected.userId,
                text: message,
                timestamp: Date.now()
            });
        }
    }
    http.send(JSON.stringify(Obj2Send));

    //let messagelist = $('#messagelist').html();
    //messagelist += `<li class="row py-1 w-100 no-gutters justify-content-end">
    //                        <div class="col-6  bg-white p-1  shadow rounded overflow-hidden">${message}</div>
    //                    </li>`;
    //$('#messagelist').html(messagelist);
}