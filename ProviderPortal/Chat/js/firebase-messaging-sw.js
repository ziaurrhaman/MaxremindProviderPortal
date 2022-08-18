importScripts('https://www.gstatic.com/firebasejs/7.10.0/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/7.10.0/firebase-messaging.js');

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
messaging.usePublicVapidKey("BIquWfQtdPbjWDjVUvbIah_Jh35GnUcjFCice3FTkc2-QMN7S6Js4Gq2bEOt7LjCQueRxUy0tCtgeaAC2JGJVvY");


/**
 * Here is is the code snippet to initialize Firebase Messaging in the Service
 * Worker when your app is not hosted on Firebase Hosting.
 // [START initialize_firebase_in_sw]
 // Give the service worker access to Firebase Messaging.
 // Note that you can only use Firebase Messaging here, other Firebase libraries
 // are not available in the service worker.
 importScripts('https://www.gstatic.com/firebasejs/7.10.0/firebase-app.js');
 importScripts('https://www.gstatic.com/firebasejs/7.10.0/firebase-messaging.js');
 // Initialize the Firebase app in the service worker by passing in the
 // messagingSenderId.
 firebase.initializeApp({
   'messagingSenderId': 'YOUR-SENDER-ID'
 });
 // Retrieve an instance of Firebase Messaging so that it can handle background
 // messages.
 const messaging = firebase.messaging();
 // [END initialize_firebase_in_sw]
 **/


// If you would like to customize notifications that are received in the
// background (Web app is closed or not in browser focus) then you should
// implement this optional method.
// [START background_handler]
messaging.setBackgroundMessageHandler(function (payload) {
    //console.log('[firebase-messaging-sw.js] Received background message ', payload);
    // Customize notification here
    const notificationTitle = 'Dummy Message';
    const notificationOptions = {
        body: payload.data.message
    };

    return self.registration.showNotification(notificationTitle,
        notificationOptions);
});