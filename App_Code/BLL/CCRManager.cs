using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Xml;

/// <summary>
/// Summary description for CCR
/// </summary>
public class CCRManager
{
    public CCRManager(string RootPath)
	{
        this.RootPath = RootPath;
        
        doc = new XmlDocument();
        
        CurrentDate = DateTime.Now.ToString("YYYY-MM-dd");
	}
    
    XmlDocument doc;
    XmlNode Node_ContinuityOfCareRecord;
    public string RootPath;
    public string CurrentDate;
    
    public void CreateCCR()
    {
        try
        {
            // Create declaration node.
            XmlNode Node_Document = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(Node_Document);
            
            // Create procesing instruction.
            string PItext = "type='text/xsl' href='CDASchemas\\cda\\Schemas\\ccr.xsl'";
            XmlProcessingInstruction newPI = doc.CreateProcessingInstruction("xml-stylesheet", PItext);
            doc.AppendChild(newPI);
            
            Node_ContinuityOfCareRecord = doc.CreateElement("ContinuityOfCareRecord");
            CreateAttribute(Node_ContinuityOfCareRecord, "xmlns", "urn:astm-org:CCR");
            CreateAttribute(Node_ContinuityOfCareRecord, "xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            CreateAttribute(Node_ContinuityOfCareRecord, "xsi:schemaLocation", "urn:astm-org:CCR CCR_20051109.xsd");
            doc.AppendChild(Node_ContinuityOfCareRecord);
            
            CreateHeader();
            CreateBody();
            CreateFooter();
            
            SaveCCR_File();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    
    public void CreateHeader()
    {
        /*Header comments*/
        CreateComments("CCR Header", Node_ContinuityOfCareRecord);
        
        /*CCRDocumentObjectID*/
        XmlNode Node_CCRDocumentObjectID = doc.CreateElement("CCRDocumentObjectID");
        XmlText ObjectIDText = doc.CreateTextNode("db734647-fc99-424c-a864-7e3cda82e703");
        Node_CCRDocumentObjectID.AppendChild(ObjectIDText);
        Node_ContinuityOfCareRecord.AppendChild(Node_CCRDocumentObjectID);
        
        /*Language*/
        XmlNode Node_Language = doc.CreateElement("Language");
        Node_ContinuityOfCareRecord.AppendChild(Node_Language);
        
        XmlNode Node_Text = doc.CreateElement("Text");
        Node_Language.AppendChild(Node_Text);
        Node_Text.InnerText = "English";

        CreateCodeNode(Node_Language, "en-US", "IETF1766");
        
        /*Version*/
        XmlNode Node_Version = doc.CreateElement("Version");
        Node_Version.InnerText = "V1.0";
        Node_ContinuityOfCareRecord.AppendChild(Node_Version);
        
        /*DateTime*/
        CreateDateTimeNode(Node_ContinuityOfCareRecord, DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz"), "");

        /*Patient*/
        XmlNode Node_Patient = doc.CreateElement("Patient");
        Node_ContinuityOfCareRecord.AppendChild(Node_Patient);

        XmlNode Node_ActorID_Patient = doc.CreateElement("ActorID");
        Node_ActorID_Patient.InnerText = "AA0001";
        Node_Patient.AppendChild(Node_ActorID_Patient);

        /*From*/
        XmlNode Node_From = doc.CreateElement("From");
        Node_ContinuityOfCareRecord.AppendChild(Node_From);

        XmlNode Node_ActorLink_From = doc.CreateElement("ActorLink");
        Node_From.AppendChild(Node_ActorLink_From);
        
        XmlNode Node_ActorID_ActorLink_From = doc.CreateElement("ActorID");
        Node_ActorLink_From.AppendChild(Node_ActorID_ActorLink_From);
        Node_ActorID_ActorLink_From.InnerText = "AA0002";
        
        XmlNode Node_ActorRole_ActorLink_From = doc.CreateElement("ActorRole");
        Node_ActorLink_From.AppendChild(Node_ActorRole_ActorLink_From);

        XmlNode Node_Text_ActorRole_ActorLink_From = doc.CreateElement("Text");
        Node_ActorRole_ActorLink_From.AppendChild(Node_Text_ActorRole_ActorLink_From);
        Node_Text_ActorRole_ActorLink_From.InnerText = "author";

        /*Purpose*/
        XmlNode Node_Purpose = doc.CreateElement("Purpose");
        Node_ContinuityOfCareRecord.AppendChild(Node_Purpose);
        
        XmlNode Node_Description_Purpose = doc.CreateElement("Description");
        Node_Purpose.AppendChild(Node_Description_Purpose);

        XmlNode Node_Text_Description_Purpose = doc.CreateElement("Text");
        Node_Description_Purpose.AppendChild(Node_Text_Description_Purpose);
        Node_Text_Description_Purpose.InnerText = "Patient Use (PHR)";

        CreateCodeNode(Node_Description_Purpose, "308292007", "SNOMED CT");
    }
    
    public void CreateBody()
    {
        CreateComments("CCR Body", Node_ContinuityOfCareRecord);
        
        XmlNode Node_Body = CreateNode("Body", Node_ContinuityOfCareRecord, "");
        
        CreateBody_Payers(Node_Body);
        CreateBody_AdvanceDirectives(Node_Body);
        CreateBody_Supporters(Node_Body);
        CreateBody_FunctionalStatus(Node_Body);
        CreateBody_Problems(Node_Body);
        CreateBody_FamilyHistory(Node_Body);
        CreateBody_SocialHistory(Node_Body);
        CreateBody_Alerts(Node_Body);
        CreateBody_Medications(Node_Body);
        CreateBody_MedicalEquipment(Node_Body);
        CreateBody_Immunizations(Node_Body);
        CreateBody_VitalSigns(Node_Body);
        CreateBody_Results(Node_Body);
        CreateBody_Procedures(Node_Body);
        CreateBody_Encounters(Node_Body);
        CreateBody_PlanOfCare(Node_Body);
        CreateBody_HealthCareProviders(Node_Body);
    }
    
    public void CreateBody_Payers(XmlNode Node_Body)
    {
        /*Payers*/
        /*Payers comments*/
        CreateComments("Payers", Node_Body);

        XmlNode Node_Payers = CreateNode("Payers", Node_Body, "");

        XmlNode Node_Payer = CreateNode("Payer", Node_Payers, "");

        CreateNode("CCRDataObjectID", Node_Payer, "1fe2cdd0-7aad-11db-9fe1-0800200c9a66");

        XmlNode Node_Type_Payer = CreateNode("Type", Node_Payer, "");

        CreateNode("Text", Node_Type_Payer, "Extended healthcare");

        CreateCodeNode(Node_Type_Payer, "EHCPOL", "ActCode");

        CreateSourceNode(Node_Payer, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_PaymentProvider_Payer = CreateNode("PaymentProvider", Node_Payer, "");

        CreateNode("ActorID", Node_PaymentProvider_Payer, "329fcdf0-7ab3-11db-9fe1-0800200c9a66");

        XmlNode Node_Subscriber_Payer = CreateNode("Subscriber", Node_Payer, "");

        CreateNode("ActorID", Node_Subscriber_Payer, "2-16-840-1-113883-19-5-996756495");

        XmlNode Node_ActorRole_Subscriber_Payer = CreateNode("ActorRole", Node_Subscriber_Payer, "");

        CreateNode("Text", Node_ActorRole_Subscriber_Payer, "Covered party");

        XmlNode Node_Authorizations_Payer = CreateNode("Authorizations", Node_Payer, "");

        XmlNode Node_Authorization_Authorizations_Payer = CreateNode("Authorization", Node_Authorizations_Payer, "");

        CreateNode("CCRDataObjectID", Node_Authorization_Authorizations_Payer, "f4dce790-8328-11db-9fe1-0800200c9a66");

        XmlNode Node_Description_Authorization_Authorizations_Payer = CreateNode("Description", Node_Authorization_Authorizations_Payer, "");

        CreateNode("Text", Node_Description_Authorization_Authorizations_Payer, "Colonoscopy");

        CreateCodeNode(Node_Description_Authorization_Authorizations_Payer, "73761001", "SNOMED CT");

        CreateSourceNode(Node_Authorization_Authorizations_Payer, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateBody_AdvanceDirectives(XmlNode Node_Body)
    {
        /*Advance Directives comments*/
        CreateComments("Advance Directives section", Node_Body);

        XmlNode Node_AdvanceDirectives = CreateNode("AdvanceDirectives", Node_Body, "");

        XmlNode Node_AdvanceDirective_AdvanceDirectives = CreateNode("AdvanceDirective", Node_AdvanceDirectives, "");

        /*CCRDataObjectID*/
        CreateNode("CCRDataObjectID", Node_AdvanceDirective_AdvanceDirectives, "9b54c3c9-1673-49c7-aef9-b037ed72ed27");

        /*DateTime*/
        CreateDateTimeNode(Node_AdvanceDirective_AdvanceDirectives, CurrentDate, "Verified With Patient");

        /*Type*/
        XmlNode Node_Type_AdvanceDirective_AdvanceDirectives = CreateNode("Type", Node_AdvanceDirective_AdvanceDirectives, "");

        CreateNode("Text", Node_Type_AdvanceDirective_AdvanceDirectives, "Resuscitation status");

        CreateCodeNode(Node_Type_AdvanceDirective_AdvanceDirectives, "304251008", "SNOMED CT");

        /*Description*/
        XmlNode Node_Description_AdvanceDirective_AdvanceDirectives = CreateNode("Description", Node_AdvanceDirective_AdvanceDirectives, "");

        CreateNode("Text", Node_Description_AdvanceDirective_AdvanceDirectives, "Do not resuscitate");

        CreateCodeNode(Node_Description_AdvanceDirective_AdvanceDirectives, "304253006", "SNOMED CT");

        /*Status*/
        XmlNode Node_Status_AdvanceDirective_AdvanceDirectives = CreateNode("Status", Node_AdvanceDirective_AdvanceDirectives, "");

        CreateNode("Text", Node_Status_AdvanceDirective_AdvanceDirectives, "Current and verified");

        CreateCodeNode(Node_Status_AdvanceDirective_AdvanceDirectives, "15240007", "SNOMED CT");

        /*Source*/
        CreateSourceNode(Node_AdvanceDirective_AdvanceDirectives, "8a54f393-8015-460c-abd2-f29aad15481c");

        /*ReferenceID*/
        CreateNode("ReferenceID", Node_AdvanceDirective_AdvanceDirectives, "b50b7910-7ffb-4f4c-bbe4-177ed68cbbf3");
    }
    
    public void CreateBody_Supporters(XmlNode Node_Body)
    {
        /*Supporters comments*/
        CreateComments("Supporters", Node_Body);

        XmlNode Node_Support = CreateNode("Support", Node_Body, "");

        XmlNode Node_SupportProvider = CreateNode("SupportProvider", Node_Support, "");

        CreateNode("ActorID", Node_SupportProvider, "4ff51570-83a9-47b7-91f2-93ba30373141");

        XmlNode Node_ActorRole = CreateNode("ActorRole", Node_SupportProvider, "");

        CreateNode("Text", Node_ActorRole, "Guardian");
    }
    
    public void CreateBody_FunctionalStatus(XmlNode Node_Body)
    {
        CreateComments("Functional Status section", Node_Body);

        XmlNode Node_FunctionalStatus = CreateNode("FunctionalStatus", Node_Body, "");

        XmlNode Node_Function = CreateNode("Function", Node_FunctionalStatus, "");

        CreateNode("CCRDataObjectID", Node_Function, "6z2fa88d-4174-4909-aece-db44b60a3abb");

        /***Type***/
        XmlNode Node_Type = CreateNode("Type", Node_Function, "");
        CreateNode("Text", Node_Type, "Ambulatory Status");

        /***Source***/
        CreateSourceNode(Node_Function, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        /***Problem***/
        XmlNode Node_Problem = CreateNode("Problem", Node_Function, "fd07111a-b15b-4dce-8518-1274d07f142a");
        CreateNode("CCRDataObjectID", Node_Problem, "");

        /*DateTime_Problem*/
        CreateDateTimeNode(Node_Problem, "1998", "");

        /*Description_Problem*/
        XmlNode Node_Description = CreateNode("Description", Node_Problem, "");
        CreateNode("Text", Node_Description, "Dependence on cane");

        /*Code_Description_Problem*/
        CreateCodeNode(Node_Description, "105504002", "SNOMED CT");

        /*Source_Problem*/
        CreateSourceNode(Node_Problem, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateBody_Problems(XmlNode Node_Body)
    {
        CreateComments("Problems section", Node_Body);
        
        XmlNode Node_Problems = CreateNode("Problems", Node_Body, "");
        
        XmlNode Node_Problem = CreateNode("Problem", Node_Problems, "");

        CreateNode("CCRDataObjectID", Node_Problem, "6a2fa88d-4174-4909-aece-db44b60a3abb");

        /*DateTime_Problem*/
        CreateDateTimeNode(Node_Problem, "1950", "");

        /*Description_Problem*/
        XmlNode Node_Description_Problem = CreateNode("Description", Node_Problem, "");
        CreateNode("Text", Node_Description_Problem, "Asthma");

        CreateCodeNode(Node_Description_Problem, "195967001", "SNOMED CT");

        /*Status_Problem*/
        XmlNode Node_Status_Problem = CreateNode("Status", Node_Problem, "");
        CreateNode("Text", Node_Status_Problem, "Active");

        CreateCodeNode(Node_Status_Problem, "55561003", "SNOMED CT");

        /*Source_Problem*/
        CreateSourceNode(Node_Problem, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateBody_FamilyHistory(XmlNode Node_Body)
    {
        CreateComments("Family History section", Node_Body);
        
        XmlNode Node_FamilyHistory = CreateNode("FamilyHistory", Node_Body, "");
        
        XmlNode Node_FamilyProblemHistory = CreateNode("FamilyProblemHistory", Node_FamilyHistory, "");
        
        CreateNode("CCRDataObjectID", Node_FamilyProblemHistory, "8a54f393-8015-460c-abd2-f29aad15481x");
        
        /*Source_FamilyProblemHistory*/
        CreateSourceNode(Node_FamilyProblemHistory, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        XmlNode Node_FamilyMember_FamilyProblemHistory = CreateNode("FamilyMember", Node_FamilyProblemHistory, "");

        CreateNode("ActorID", Node_FamilyMember_FamilyProblemHistory, "8854f393-8015-460c-abd2-f29aad15481c");
        
        XmlNode Node_ActorRole_FamilyMember_FamilyProblemHistory = CreateNode("ActorRole", Node_FamilyMember_FamilyProblemHistory, "");
        CreateNode("Text", Node_ActorRole_FamilyMember_FamilyProblemHistory, "Father");
        
        XmlNode Node_HealthStatus_FamilyMember_FamilyProblemHistory = CreateNode("HealthStatus", Node_FamilyMember_FamilyProblemHistory, "");
        XmlNode Node_Description_HealthStatus_FamilyMember_FamilyProblemHistory = CreateNode("Description", Node_HealthStatus_FamilyMember_FamilyProblemHistory, "");
        CreateNode("Text", Node_Description_HealthStatus_FamilyMember_FamilyProblemHistory, "Deceased");

        CreateNode("CauseOfDeath", Node_HealthStatus_FamilyMember_FamilyProblemHistory, "Yes");

        CreateSourceNode(Node_HealthStatus_FamilyMember_FamilyProblemHistory, "8a54f393-8015-460c-abd2-f29aad15481c");

        CreateSourceNode(Node_FamilyMember_FamilyProblemHistory, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        /*Problem_FamilyProblemHistory*/
        XmlNode Node_Problem_FamilyProblemHistory = CreateNode("Problem", Node_FamilyProblemHistory, "");

        XmlNode Node_Description_Problem_FamilyProblemHistory = CreateNode("Description", Node_Problem_FamilyProblemHistory, "");
        CreateNode("Text", Node_Description_Problem_FamilyProblemHistory, "Myocardial Infarction");

        CreateCodeNode(Node_Description_Problem_FamilyProblemHistory, "22298006", "SNOMED CT");

        /*Episodes_Problem_FamilyProblemHistory*/
        XmlNode Node_Episodes_Problem_FamilyProblemHistory = CreateNode("Episodes", Node_Problem_FamilyProblemHistory, "");
        
        CreateNode("Number", Node_Episodes_Problem_FamilyProblemHistory, "1");
        XmlNode Node_Episode_Episodes_Problem_FamilyProblemHistory = CreateNode("Episode", Node_Episodes_Problem_FamilyProblemHistory, "");
        CreateNode("CCRDataObjectID", Node_Episode_Episodes_Problem_FamilyProblemHistory, "d42ebf70-5c89-11db-b0de-0800200c9a66");

        CreateDateTimeNode(Node_Episode_Episodes_Problem_FamilyProblemHistory, "", "Age At Onset");

        CreateSourceNode(Node_Episode_Episodes_Problem_FamilyProblemHistory, "8a54f393-8015-460c-abd2-f29aad15481c");

        /*Source_Episodes*/
        CreateSourceNode(Node_Episodes_Problem_FamilyProblemHistory, "8a54f393-8015-460c-abd2-f29aad15481c");

        /*Source_Problem*/
        CreateSourceNode(Node_Problem_FamilyProblemHistory, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateBody_SocialHistory(XmlNode Node_Body)
    {
        CreateComments("Social History section", Node_Body);
        
        XmlNode Node_SocialHistory = CreateNode("SocialHistory", Node_Body, "");
        
        XmlNode Node_SocialHistoryElement = CreateNode("SocialHistoryElement", Node_SocialHistory, "");
        
        CreateNode("CCRDataObjectID", Node_SocialHistoryElement, "24d86ead-d780-4218-a5ac-8035c3915658");
        
        /*Type_SocialHistoryElement*/
        XmlNode Node_Type_SocialHistoryElement = CreateNode("Type", Node_SocialHistoryElement, "");
        CreateNode("Text", Node_Type_SocialHistoryElement, "Smoking");

        CreateCodeNode(Node_Type_SocialHistoryElement, "230056004", "SNOMED CT");
        
        /*Source_SocialHistoryElement*/
        CreateSourceNode(Node_SocialHistoryElement, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        /*Episodes_SocialHistoryElement*/
        XmlNode Node_Episodes = CreateNode("Episodes", Node_SocialHistoryElement, "");
        
        XmlNode Node_Episode = CreateNode("Episode", Node_Episodes, "");
        CreateNode("CCRDataObjectID", Node_Episode, "d42ebf70-5c89-11db-b0de-0800200c9a66");
        
        XmlNode Node_DateTime_Episode = CreateNode("DateTime", Node_Episode, "");
        
        XmlNode Node_DateTimeRange_DateTime_Episode = CreateNode("DateTimeRange", Node_DateTime_Episode, "");
        
        XmlNode Node_BeginRange_DateTimeRange_DateTime_Episode = CreateNode("BeginRange", Node_DateTimeRange_DateTime_Episode, "");
        CreateNode("ExactDateTime", Node_BeginRange_DateTimeRange_DateTime_Episode, "1947");
        
        XmlNode Node_EndRange_DateTimeRange_DateTime_Episode = CreateNode("EndRange", Node_DateTimeRange_DateTime_Episode, "");
        CreateNode("ExactDateTime", Node_EndRange_DateTimeRange_DateTime_Episode, "1972");
        
        XmlNode Node_Description_Episode = CreateNode("Description", Node_Episode, "");
        CreateNode("Text", Node_Description_Episode, "1 pack per day");

        CreateSourceNode(Node_Episode, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        /*Source_Episodes*/
        CreateSourceNode(Node_Episodes, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateBody_Alerts(XmlNode Node_Body)
    {
        CreateComments("Alerts section", Node_Body);
        
        XmlNode Node_Alerts = CreateNode("Alerts", Node_Body, "");
        
        /*Loop*/
        XmlNode Node_Alert = CreateNode("Alert", Node_Alerts, "");
        
        CreateNode("CCRDataObjectID", Node_Alert, "36e3e930-7b14-11db-9fe1-0800200c9a66");
        
        /*Description_Alert*/
        XmlNode Node_Description_Alert = CreateNode("Description", Node_Alert, "");
        CreateNode("Text", Node_Description_Alert, "Adverse reaction to substance");

        CreateCodeNode(Node_Description_Alert, "282100009", "SNOMED CT");
        
        /*Status_Alert*/
        XmlNode Node_Status_Alert = CreateNode("Status", Node_Alert, "");
        CreateNode("Text", Node_Status_Alert, "Active");

        /*Source_Alert*/
        CreateSourceNode(Node_Alert, "8a54f393-8015-460c-abd2-f29aad15481c");

        /*Agent_Alert*/
        XmlNode Node_Agent_Alert = CreateNode("Agent", Node_Alert, "");
        
        XmlNode Node_Products_Agent = CreateNode("Products", Node_Agent_Alert, "");

        /*Product_Products*/
        XmlNode Node_Product = CreateNode("Product", Node_Products_Agent, "");
        CreateNode("CCRDataObjectID", Node_Product, "44c83e90-2db3-4a7f-8819-2552c342b65b");

        CreateSourceNode(Node_Product, "8a54f393-8015-460c-abd2-f29aad15481c");

        /*Product_Product_Products*/
        XmlNode Node_Product_Product = CreateNode("Product", Node_Product, "");
        
        XmlNode Node_ProductName_Product_Product = CreateNode("ProductName", Node_Product_Product, "");
        CreateNode("Text", Node_ProductName_Product_Product, "Penicillin");

        CreateCodeNode(Node_ProductName_Product_Product, "70618", "RxNorm");

        /*Reaction_Alert*/
        XmlNode Node_Reaction_Alert = CreateNode("Reaction", Node_Alert, "");

        XmlNode Node_Description_Reaction_Alert = CreateNode("Description", Node_Reaction_Alert, "");
        CreateNode("Text", Node_Description_Reaction_Alert, "Hives");

        CreateCodeNode(Node_Description_Reaction_Alert, "247472004", "SNOMED CT");
    }
    
    public void CreateBody_Medications(XmlNode Node_Body)
    {
        CreateComments("Medications section", Node_Body);
        
        XmlNode Node_Medications = CreateNode("Medications", Node_Body, "");
        
        /*Loop*/
        XmlNode Node_Medication = CreateNode("Medication", Node_Medications, "");
        
        CreateNode("CCRDataObjectID", Node_Medication, "cdbd33f0-6cde-11db-9fe1-0800200c9a66");
        
        XmlNode Node_Status_Medication = CreateNode("Status", Node_Medication, "");
        CreateNode("Text", Node_Status_Medication, "Active");

        CreateSourceNode(Node_Medication, "8a54f393-8015-460c-abd2-f29aad15481c");

        /*Product_Medication*/
        XmlNode Node_Product_Medication = CreateNode("Product", Node_Medication, "");

        XmlNode Node_ProductName_Product_Medication = CreateNode("ProductName", Node_Product_Medication, "");
        CreateNode("Text", Node_ProductName_Product_Medication, "Albuterol inhalant");

        CreateCodeNode(Node_ProductName_Product_Medication, "307782", "RxNorm");

        /*Directions_Medication*/
        XmlNode Node_Directions_Medication = CreateNode("Directions", Node_Medication, "");
        XmlNode Node_Direction_Medication = CreateNode("Direction", Node_Directions_Medication, "");

        XmlNode Node_Dose_Direction_Medication = CreateNode("Dose", Node_Directions_Medication, "");
        CreateNode("Value", Node_Dose_Direction_Medication, "2");

        XmlNode Node_Route_Direction_Medication = CreateNode("Route", Node_Directions_Medication, "");
        CreateCodeNode(Node_Route_Direction_Medication, "IPINHL", "RouteOfAdministration");

        XmlNode Node_Frequency_Direction_Medication = CreateNode("Frequency", Node_Directions_Medication, "");
        CreateNode("Value", Node_Frequency_Direction_Medication, "QID");

        XmlNode Node_Indication_Direction_Medication = CreateNode("Indication", Node_Directions_Medication, "");
        
        XmlNode Node_PRNFlag_Indication_Direction_Medication = CreateNode("PRNFlag", Node_Indication_Direction_Medication, "");
        CreateNode("Text", Node_PRNFlag_Indication_Direction_Medication, "Wheezing");
        CreateCodeNode(Node_PRNFlag_Indication_Direction_Medication, "56018004", "SNOMED CT");

        CreateSourceNode(Node_Indication_Direction_Medication, "8a54f393-8015-460c-abd2-f29aad15481c");


    }
    
    public void CreateBody_MedicalEquipment(XmlNode Node_Body)
    {
        CreateComments("Medical Equipment section", Node_Body);
        
        XmlNode Node_MedicalEquipment = CreateNode("MedicalEquipment", Node_Body, "");
        
        /*Loop*/
        XmlNode Node_Equipment = CreateNode("Medication", Node_MedicalEquipment, "");
        CreateNode("CCRDataObjectID", Node_Equipment, "2413773c-2372-4299-bbe6-5b0f60664446");

        CreateDateTimeNode(Node_Equipment, "1999-11", "");
        
        CreateSourceNode(Node_Equipment, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        XmlNode Node_Product_Equipment = CreateNode("Product", Node_Equipment, "");
        XmlNode Node_ProductName_Product_Equipment = CreateNode("ProductName", Node_Product_Equipment, "");
        CreateNode("Text", Node_ProductName_Product_Equipment, "Automatic implantable cardioverter/defibrillator");
        CreateCodeNode(Node_ProductName_Product_Equipment, "72506001", "SNOMED CT");
    }
    
    public void CreateBody_Immunizations(XmlNode Node_Body)
    {
        CreateComments("Immunizations section", Node_Body);

        XmlNode Node_Immunizations = CreateNode("Immunizations", Node_Body, "");

        /*Loop*/
        XmlNode Node_Immunization = CreateNode("Immunization", Node_Immunizations, "");
        CreateNode("CCRDataObjectID", Node_Immunization, "e6f1ba43-c0ed-4b9b-9f12-f435d8ad8f92");

        CreateDateTimeNode(Node_Immunization, "1999-11", "Immunization Date");
        CreateSourceNode(Node_Immunization, "c1a4582d-eade-44e0-9f04-7b70c96c5e51");

        XmlNode Node_Product_Immunization = CreateNode("Product", Node_Immunizations, "");

        XmlNode Node_ProductName_Product_Immunization = CreateNode("ProductName", Node_Product_Immunization, "");
        CreateNode("Text", Node_ProductName_Product_Immunization, "Influenza virus vaccine");
        
        CreateCodeNode(Node_ProductName_Product_Immunization, "88", "CDC Vaccine Code");
    }
    
    public void CreateBody_VitalSigns(XmlNode Node_Body)
    {
        CreateComments("Vital Signs section", Node_Body);

        XmlNode Node_VitalSigns = CreateNode("VitalSigns", Node_Body, "");

        /*Loop*/
        XmlNode Node_Result = CreateNode("Result", Node_VitalSigns, "");
        CreateNode("CCRDataObjectID", Node_Result, "c6f88320-67ad-11db-bd13-0800200c9a66");

        CreateDateTimeNode(Node_Result, "1999-11-14", "Assessment Time");
        XmlNode Node_Type_Result = CreateTypeNode(Node_Result, "Vital Signs");
        CreateCodeNode(Node_Type_Result, "46680005", "SNOMED CT");
        
        CreateStatusNode(Node_Result, "Final Results");
        
        CreateSourceNode(Node_Result, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        /*Loop*/
        XmlNode Node_Test = CreateNode("Test", Node_Result, "");
        CreateNode("CCRDataObjectID", Node_Test, "c6f88321-67ad-11db-bd13-0800200c9a66");

        CreateDateTimeNode(Node_Test, "1999-11-14", "Assessment Time");

        XmlNode Node_Description_Test = CreateDescriptionNode(Node_Test, "Body height");
        CreateCodeNode(Node_Description_Test, "50373000", "SNOMED CT");

        CreateStatusNode(Node_Test, "Final Results");

        CreateSourceNode(Node_Test, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_TestResult = CreateNode("TestResult", Node_Test, "");
        CreateNode("Value", Node_TestResult, "177");

        XmlNode Node_Units_TestResult = CreateNode("Units", Node_TestResult, "");
        CreateNode("Unit", Node_Units_TestResult, "cm");
    }
    
    public void CreateBody_Results(XmlNode Node_Body)
    {
        CreateComments("Results section", Node_Body);
        
        XmlNode Node_Results = CreateNode("Results", Node_Body, "");
        
        /*Loop*/
        XmlNode Node_Result = CreateNode("Result", Node_Results, "");
        CreateNode("CCRDataObjectID", Node_Result, "7d5a02b0-67a4-11db-bd13-0800200c9a66");
        
        CreateDateTimeNode(Node_Result, "2000-04-07T14:30Z", "Assessment Time");
        
        XmlNode Node_Description_Result = CreateDescriptionNode(Node_Result, "CBC WO DIFFERENTIAL");
        CreateCodeNode(Node_Description_Result, "43789009", "SNOMED CT");
        
        CreateStatusNode(Node_Result, "Final Results");
        
        CreateSourceNode(Node_Result, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        XmlNode Node_Test_Result = CreateNode("Test", Node_Result, "");
        CreateNode("CCRDataObjectID", Node_Test_Result, "107c2dc0-67a5-11db-bd13-0800200c9a66");

        CreateDateTimeNode(Node_Test_Result, "2000-04-07T14:30Z", "Assessment Time");

        XmlNode Node_Description_Test_Result = CreateDescriptionNode(Node_Test_Result, "HGB");
        CreateCodeNode(Node_Description_Test_Result, "30313-1", "LOINC");

        CreateStatusNode(Node_Test_Result, "Final Results");

        CreateSourceNode(Node_Test_Result, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_TestResult_Test = CreateNode("TestResult", Node_Test_Result, "");
        CreateNode("Value", Node_TestResult_Test, "13.2");
        XmlNode Node_Units_TestResult = CreateNode("Units", Node_TestResult_Test, "");
        CreateNode("Unit", Node_Units_TestResult, "g/dl");

        XmlNode Node_NormalResult_Test = CreateNode("NormalResult", Node_Test_Result, "");
        XmlNode Node_Normal_NormalResult = CreateNode("Normal", Node_NormalResult_Test, "");
        CreateDescriptionNode(Node_Normal_NormalResult, "M 13-18 g/dl; F 12-16 g/dl");

        CreateSourceNode(Node_Normal_NormalResult, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateBody_Procedures(XmlNode Node_Body)
    {
        CreateComments("Procedures section", Node_Body);
        
        XmlNode Node_Procedures = CreateNode("Procedures", Node_Body, "");
        
        /*Loop*/
        XmlNode Node_Procedure = CreateNode("Procedure", Node_Procedures, "");
        CreateNode("CCRDataObjectID", Node_Procedure, "e401f340-7be2-11db-9fe1-0800200c9a66");
        
        CreateDateTimeNode(Node_Procedure, "1998", "Procedure Date");
        
        XmlNode Node_Description_Procedure = CreateDescriptionNode(Node_Procedure, "Total hip replacement, left");
        
        XmlNode Node_ObjectAttribute_Description_Procedure = CreateNode("ObjectAttribute", Node_Description_Procedure, "");
        CreateNode("Attribute", Node_ObjectAttribute_Description_Procedure, "Laterality");
        XmlNode Node_AttributeValue_ObjectAttribute = CreateNode("AttributeValue", Node_ObjectAttribute_Description_Procedure, "");
        CreateNode("Value", Node_AttributeValue_ObjectAttribute, "Left");
        CreateCodeNode(Node_AttributeValue_ObjectAttribute, "7771000", "SNOMED CT");

        CreateCodeNode(Node_Description_Procedure, "52734007", "SNOMED CT");

        CreateStatusNode(Node_Procedure, "Completed");

        CreateSourceNode(Node_Procedure, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_InternalCCRLink_Procedure = CreateNode("InternalCCRLink", Node_Procedure, "");
        CreateNode("LinkID", Node_InternalCCRLink_Procedure, "3a5742fe-47fd-4ad7-a303-6c65067c4470");
        CreateNode("LinkRelationship", Node_InternalCCRLink_Procedure, "Implanted equipment");
    }
    
    public void CreateBody_Encounters(XmlNode Node_Body)
    {
        CreateComments("Encounters section", Node_Body);
        
        XmlNode Node_Encounters = CreateNode("Encounters", Node_Body, "");
        
        /*Loop*/
        XmlNode Node_Encounter = CreateNode("Encounter", Node_Encounters, "");
        CreateNode("CCRDataObjectID", Node_Encounter, "2a620155-9d11-439e-92b3-5d9815ff4de8");

        XmlNode Node_Type_Encounter = CreateTypeNode(Node_Encounter, "Checkup Examination");
        CreateCodeNode(Node_Type_Encounter, "GENRL", "2.16.840.1.113883.5.4");

        CreateSourceNode(Node_Encounter, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_Locations_Encounter = CreateNode("Locations", Node_Encounter, "");
        XmlNode Node_Location_Locations = CreateNode("Location", Node_Locations_Encounter, "");
        XmlNode Node_Actor_Location = CreateNode("Actor", Node_Location_Locations, "");
        CreateNode("ActorID", Node_Actor_Location, "2.16.840.1.113883.19.5");
    }
    
    public void CreateBody_PlanOfCare(XmlNode Node_Body)
    {
        CreateComments("Plan of Care section", Node_Body);
        
        XmlNode Node_PlanOfCare = CreateNode("PlanOfCare", Node_Body, "");
        
        /*Loop*/
        XmlNode Node_Plan = CreateNode("Plan", Node_PlanOfCare, "");
        CreateNode("CCRDataObjectID", Node_Plan, "aaad1bac-17d3-4195-89a4-1121bc809b4a");
        
        CreateSourceNode(Node_Plan, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_OrderRequest_Plan = CreateNode("OrderRequest", Node_Plan, "");
        CreateNode("CCRDataObjectID", Node_OrderRequest_Plan, "bbbd1bac-17d3-4195-89a4-1121bc809b4a");

        CreateDateTimeNode(Node_OrderRequest_Plan, "2000-04-21", "Requested date");

        CreateStatusNode(Node_OrderRequest_Plan, "Ordered");

        CreateSourceNode(Node_OrderRequest_Plan, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_Procedures_OrderRequest = CreateNode("Procedures", Node_Plan, "");

        XmlNode Node_Procedure = CreateNode("Procedure", Node_Plan, "");
        CreateNode("CCRDataObjectID", Node_Procedure, "9a6d1bac-17d3-4195-89a4-1121bc809b4a");

        XmlNode Node_Type_Procedure = CreateTypeNode(Node_Procedure, "Pulmonary function test");
        CreateCodeNode(Node_Type_Procedure, "23426006", "SNOMED CT");

        CreateSourceNode(Node_Procedure, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateBody_HealthCareProviders(XmlNode Node_Body)
    {
        CreateComments("Healthcare providers", Node_Body);

        XmlNode Node_HealthCareProviders = CreateNode("HealthCareProviders", Node_Body, "");

        /*Loop*/
        XmlNode Node_Provider = CreateNode("Provider", Node_HealthCareProviders, "");
        CreateNode("ActorID", Node_Provider, "20cf14fb-b65c-4c8c-a54d-b0cca834c18c");

        XmlNode Node_ActorRole_Provider = CreateNode("ActorRole", Node_Provider, "");
        CreateNode("Text", Node_ActorRole_Provider, "Primary Care Provider");

        CreateCodeNode(Node_ActorRole_Provider, "PCP", "2.16.840.1.113883.5.88");
    }
    
    
    
    /*Start Footer Functions*/
    public void CreateFooter()
    {
        CreateComments("CCR Footer", Node_ContinuityOfCareRecord);
        CreateFooter_Actors();
        CreateFooter_References();
    }
    
    public void CreateFooter_Actors()
    {
        CreateComments("Actors", Node_ContinuityOfCareRecord);
        
        XmlNode Node_Actors = CreateNode("Actors", Node_ContinuityOfCareRecord, "");
        CreateSimpleComments("Actor Persons", Node_Actors);
        
        CreateFooter_Actor_Patient(Node_Actors);
        CreateFooter_Actor_PrimaryCareProvider(Node_Actors);
        CreateFooter_Actor_Guardian(Node_Actors);
        CreateFooter_Actor_Mother(Node_Actors);
        CreateFooter_Actor_Father(Node_Actors);
        CreateFooter_Actor_Organizations(Node_Actors);
        CreateFooter_Actor_InformationSystems(Node_Actors);
        CreateFooter_Actor_OtherActors(Node_Actors);
    }

    public void CreateFooter_Actor_Patient(XmlNode Node_Actors)
    {
        CreateSimpleComments("Patient", Node_Actors);

        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");

        CreateNode("ActorObjectID", Node_Actor, "2-16-840-1-113883-19-5-996756495");

        XmlNode Node_Person_Actor = CreateNode("Person", Node_Actor, "");

        XmlNode Node_Name_Person = CreateNode("Name", Node_Person_Actor, "");

        XmlNode Node_CurrentName_Name = CreateNode("CurrentName", Node_Name_Person, "");
        CreateNode("Given", Node_CurrentName_Name, "Henry");
        CreateNode("Family", Node_CurrentName_Name, "Levin");
        CreateNode("Suffix", Node_CurrentName_Name, "the 7th");

        XmlNode Node_DateOfBirth_Person = CreateNode("DateOfBirth", Node_Person_Actor, "");
        CreateNode("ExactDateTime", Node_DateOfBirth_Person, "1932-09-24");

        XmlNode Node_Gender_Person = CreateNode("Gender", Node_Person_Actor, "");
        CreateNode("Text", Node_Gender_Person, "Male");
        CreateCodeNode(Node_Gender_Person, "M", "2.16.840.1.113883.5.1");

        /*Loop IDs*/
        XmlNode Node_IDs_Actor = CreateNode("IDs", Node_Actor, "");
        CreateTypeNode(Node_IDs_Actor, "Patient ID");
        CreateNode("ID", Node_IDs_Actor, "2-16-840-1-113883-19-5-996756495");

        XmlNode Node_IssuedBy_IDs = CreateNode("IssuedBy", Node_IDs_Actor, "");
        CreateNode("ActorID", Node_IssuedBy_IDs, "2.16.840.1.113883.19.5");

        CreateSourceNode(Node_IDs_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");

        /*Source_Actor*/
        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");

    }

    public void CreateFooter_Actor_PrimaryCareProvider(XmlNode Node_Actors)
    {
        CreateSimpleComments("Primary care provider", Node_Actors);

        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");

        CreateNode("ActorObjectID", Node_Actor, "20cf14fb-b65c-4c8c-a54d-b0cca834c18c");

        XmlNode Node_Person_Actor = CreateNode("Person", Node_Actor, "");
        
        XmlNode Node_Name_Person = CreateNode("Name", Node_Person_Actor, "");
        
        XmlNode Node_CurrentName_Name = CreateNode("CurrentName", Node_Name_Person, "");
        CreateNode("Given", Node_CurrentName_Name, "Henry");
        CreateNode("Family", Node_CurrentName_Name, "Levin");
        CreateNode("Title", Node_CurrentName_Name, "Dr.");
        
        /*Loop IDs*/
        XmlNode Node_IDs_Actor = CreateNode("IDs", Node_Actor, "");
        CreateNode("ID", Node_IDs_Actor, "20cf14fb-b65c-4c8c-a54d-b0cca834c18c");
        
        XmlNode Node_IssuedBy_IDs = CreateNode("IssuedBy", Node_IDs_Actor, "");
        CreateNode("ActorID", Node_IssuedBy_IDs, "2.16.840.1.113883.19.5");

        CreateSourceNode(Node_IDs_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
        
        /*Source_Actor*/
        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }

    public void CreateFooter_Actor_Guardian(XmlNode Node_Actors)
    {
        CreateSimpleComments("Guardian", Node_Actors);

        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");

        CreateNode("ActorObjectID", Node_Actor, "4ff51570-83a9-47b7-91f2-93ba30373141");

        XmlNode Node_Person_Actor = CreateNode("Person", Node_Actor, "");

        XmlNode Node_Name_Person = CreateNode("Name", Node_Person_Actor, "");

        XmlNode Node_CurrentName_Name = CreateNode("CurrentName", Node_Name_Person, "");
        CreateNode("Given", Node_CurrentName_Name, "Kenneth");
        CreateNode("Family", Node_CurrentName_Name, "Ross");

        XmlNode Node_Address_Actor = CreateNode("Address", Node_Actor, "");
        CreateNode("Line1", Node_Address_Actor, "17 Daws Rd.");
        CreateNode("City", Node_Address_Actor, "Blue Bell");
        CreateNode("State", Node_Address_Actor, "MA");
        CreateNode("PostalCode", Node_Address_Actor, "02368");

        XmlNode Node_Telephone_Actor = CreateNode("Telephone", Node_Actor, "");
        CreateNode("Value", Node_Telephone_Actor, "tel:(888)555-1212");

        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }

    public void CreateFooter_Actor_Mother(XmlNode Node_Actors)
    {
        CreateSimpleComments("Mother", Node_Actors);
        
        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");
        
        CreateNode("ActorObjectID", Node_Actor, "4ac71514-6a10-4164-9715-f8d96af48e6d");
        
        XmlNode Node_Person_Actor = CreateNode("Person", Node_Actor, "");
        XmlNode Node_Name_Person = CreateNode("Name", Node_Person_Actor, "");
        XmlNode Node_CurrentName_Name = CreateNode("CurrentName", Node_Name_Person, "");
        CreateNode("Given", Node_CurrentName_Name, "Henrietta");
        CreateNode("Family", Node_CurrentName_Name, "Levin");
        XmlNode Node_DateOfBirth_Name = CreateNode("DateOfBirth", Node_Name_Person, "");
        CreateNode("ExactDateTime", Node_DateOfBirth_Name, "1912");
        XmlNode Node_Gender_Person = CreateNode("Gender", Node_Person_Actor, "");
        CreateNode("Text", Node_Gender_Person, "Female");
        CreateCodeNode(Node_Gender_Person, "F", "2.16.840.1.113883.5.1");
        
        
        XmlNode Node_Relation_Actor = CreateNode("Relation", Node_Actor, "");
        CreateNode("Text", Node_Relation_Actor, "Biological mother");
        CreateCodeNode(Node_Relation_Actor, "65656005", "SNOMED CT");

        
        XmlNode Node_Telephone_Actor = CreateNode("Telephone", Node_Actor, "");
        CreateNode("Value", Node_Telephone_Actor, "tel:(999)555-1212");

        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }

    public void CreateFooter_Actor_Father(XmlNode Node_Actors)
    {
        CreateSimpleComments("Father", Node_Actors);
        
        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");
        
        CreateNode("ActorObjectID", Node_Actor, "8854f393-8015-460c-abd2-f29aad15481c");
        
        XmlNode Node_Person_Actor = CreateNode("Person", Node_Actor, "");
        XmlNode Node_Name_Person = CreateNode("Name", Node_Person_Actor, "");
        XmlNode Node_CurrentName_Name = CreateNode("CurrentName", Node_Name_Person, "");
        CreateNode("Given", Node_CurrentName_Name, "Henry");
        CreateNode("Family", Node_CurrentName_Name, "Levin");
        CreateNode("Suffix", Node_CurrentName_Name, "the 6th");

        XmlNode Node_DateOfBirth_Name = CreateNode("DateOfBirth", Node_Name_Person, "");
        CreateNode("ExactDateTime", Node_DateOfBirth_Name, "1912");

        XmlNode Node_Gender_Person = CreateNode("Gender", Node_Person_Actor, "");
        CreateNode("Text", Node_Gender_Person, "Male");
        CreateCodeNode(Node_Gender_Person, "M", "2.16.840.1.113883.5.1");


        XmlNode Node_Relation_Actor = CreateNode("Relation", Node_Actor, "");
        CreateNode("Text", Node_Relation_Actor, "Biological father");
        CreateCodeNode(Node_Relation_Actor, "9947008", "SNOMED CT");


        XmlNode Node_Telephone_Actor = CreateNode("Telephone", Node_Actor, "");
        CreateNode("Value", Node_Telephone_Actor, "tel:(999)555-1212");

        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }

    public void CreateFooter_Actor_Organizations(XmlNode Node_Actors)
    {
        CreateSimpleComments("Actor Organizations", Node_Actors);
        CreateFooter_Actor_Organizations_GoodHealthClinic(Node_Actors);
        CreateFooter_Actor_Organizations_GoodHealthInsurance(Node_Actors);
        CreateFooter_Actor_Organizations_GoodHealthProsthesesCompany(Node_Actors);
    }
    
    public void CreateFooter_Actor_Organizations_GoodHealthClinic(XmlNode Node_Actors)
    {
        CreateSimpleComments("Good Health Clinic", Node_Actors);

        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");

        CreateNode("ActorObjectID", Node_Actor, "2.16.840.1.113883.19.5");

        XmlNode Node_Organization_Actor = CreateNode("Organization", Node_Actor, "");
        CreateNode("Name", Node_Organization_Actor, "Good Health Clinic");

        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateFooter_Actor_Organizations_GoodHealthInsurance(XmlNode Node_Actors)
    {
        CreateSimpleComments("Good Health Insurance", Node_Actors);

        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");

        CreateNode("ActorObjectID", Node_Actor, "329fcdf0-7ab3-11db-9fe1-0800200c9a66");

        XmlNode Node_Organization_Actor = CreateNode("Organization", Node_Actor, "");
        CreateNode("Name", Node_Organization_Actor, "Good Health Insurance");

        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateFooter_Actor_Organizations_GoodHealthProsthesesCompany(XmlNode Node_Actors)
    {
        CreateSimpleComments("Good Health Prostheses Company", Node_Actors);

        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");

        CreateNode("ActorObjectID", Node_Actor, "0abea950-5b40-4b7e-b8d9-2a5ea3ac5500");

        XmlNode Node_Organization_Actor = CreateNode("Organization", Node_Actor, "");
        CreateNode("Name", Node_Organization_Actor, "Good Health Prostheses Company");

        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateFooter_Actor_InformationSystems(XmlNode Node_Actors)
    {
        CreateSimpleComments("Actor Information Systems", Node_Actors);
        CreateFooter_Actor_InformationSystems_CCD_AuthoringDevice(Node_Actors);
        CreateFooter_Actor_InformationSystems_ImmunizationTrackingSystem(Node_Actors);
    }
    
    public void CreateFooter_Actor_InformationSystems_CCD_AuthoringDevice(XmlNode Node_Actors)
    {
        CreateSimpleComments("CCD authoring device", Node_Actors);

        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");

        CreateNode("ActorObjectID", Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_InformationSystem_Actor = CreateNode("InformationSystem", Node_Actor, "");
        CreateNode("Name", Node_InformationSystem_Actor, "Good Health Clinic System v1.0");

        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateFooter_Actor_InformationSystems_ImmunizationTrackingSystem(XmlNode Node_Actors)
    {
        CreateSimpleComments("Immunization Tracking System", Node_Actors);

        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");

        CreateNode("ActorObjectID", Node_Actor, "c1a4582d-eade-44e0-9f04-7b70c96c5e51");

        XmlNode Node_InformationSystem_Actor = CreateNode("InformationSystem", Node_Actor, "");
        CreateNode("Name", Node_InformationSystem_Actor, "Immunization Tracking System");

        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateFooter_Actor_OtherActors(XmlNode Node_Actors)
    {
        CreateSimpleComments("Other Actors", Node_Actors);
        CreateSimpleComments("URL for referenced Advance directive document", Node_Actors);
        
        XmlNode Node_Actor = CreateNode("Actor", Node_Actors, "");
        
        CreateNode("ActorObjectID", Node_Actor, "b50b7910-7ffb-4f4c-bbe4-177ed68cbbf3");
        
        XmlNode Node_URL_Actor = CreateNode("URL", Node_Actor, "");
        CreateNode("Value", Node_URL_Actor, "AdvanceDirective.b50b7910-7ffb-4f4c-bbe4-177ed68cbbf3.pdf");
        
        CreateSourceNode(Node_Actor, "8a54f393-8015-460c-abd2-f29aad15481c");
    }
    
    public void CreateFooter_References()
    {
        CreateComments("References", Node_ContinuityOfCareRecord);
        
        XmlNode Node_References = CreateNode("References", Node_ContinuityOfCareRecord, "");
        
        /*Loop*/
        XmlNode Node_Reference = CreateNode("Reference", Node_References, "");
        CreateNode("ReferenceObjectID", Node_Reference, "b50b7910-7ffb-4f4c-bbe4-177ed68cbbf3");
        
        XmlNode Node_Description_Reference = CreateNode("Description", Node_Reference, "");
        CreateNode("Text", Node_Description_Reference, "Advance directive");
        
        CreateCodeNode(Node_Description_Reference, "371538006", "SNOMED CT");
        CreateSourceNode(Node_Reference, "8a54f393-8015-460c-abd2-f29aad15481c");

        XmlNode Node_Locations_Reference = CreateNode("Locations", Node_Reference, "");
        
        /*Loop*/
        XmlNode Node_Location_Locations = CreateNode("Location", Node_Locations_Reference, "");
        XmlNode Node_Actor_Location = CreateNode("Actor", Node_Location_Locations, "");
        CreateNode("ActorID", Node_Actor_Location, "b50b7910-7ffb-4f4c-bbe4-177ed68cbbf3");


        CreateComments("Comments", Node_ContinuityOfCareRecord);
        CreateComments("Signatures", Node_ContinuityOfCareRecord);
    }
    
    /*End Footer Functions*/

    
    public XmlNode CreateNode(string NodeName, XmlNode ParentNode, string InnerText)
    {
        XmlNode objNode = doc.CreateElement(NodeName);
        ParentNode.AppendChild(objNode);

        if (InnerText != "")
        {
            objNode.InnerText = InnerText;
        }

        return objNode;
    }
    
    public void CreateAttribute(XmlNode appendToNode, string attributeName, string attributeValue)
    {
        XmlAttribute attr = doc.CreateAttribute(attributeName);
        attr.Value = attributeValue;
        
        appendToNode.Attributes.Append(attr);
    }
    
    public void CreateCodeNode(XmlNode ParentNode, string Value, string CodingSystem)
    {
        XmlNode Node_Code = CreateNode("Code", ParentNode, "");
        CreateNode("Value", Node_Code, Value);
        CreateNode("CodingSystem", Node_Code, CodingSystem);
    }
    
    public void CreateSourceNode(XmlNode ParentNode, string ActorID)
    {
        XmlNode Node_Source = CreateNode("Source", ParentNode, "");
        XmlNode Node_Actor = CreateNode("Actor", Node_Source, "");
        CreateNode("ActorID", Node_Actor, ActorID);
    }
    
    public void CreateDateTimeNode(XmlNode ParentNode, string ExactDateTime, string Text)
    {
        XmlNode Node_DateTime = CreateNode("DateTime", ParentNode, "");
        
        if (!string.IsNullOrEmpty(Text))
        {
            XmlNode Node_Type = CreateNode("Type", Node_DateTime, "");
            CreateNode("Text", Node_Type, Text);
        }
        
        if (!string.IsNullOrEmpty(ExactDateTime))
        {
            CreateNode("ExactDateTime", Node_DateTime, ExactDateTime);
        }
    }

    public XmlNode CreateTypeNode(XmlNode ParentNode, string Text)
    {
        XmlNode Node_Type = CreateNode("Type", ParentNode, "");

        if (!string.IsNullOrEmpty(Text))
        {
            CreateNode("Text", Node_Type, Text);
        }

        return Node_Type;
    }

    public XmlNode CreateDescriptionNode(XmlNode ParentNode, string Text)
    {
        XmlNode Node_Description = CreateNode("Description", ParentNode, "");

        if (!string.IsNullOrEmpty(Text))
        {
            CreateNode("Text", Node_Description, Text);
        }

        return Node_Description;
    }

    public void CreateStatusNode(XmlNode ParentNode, string Text)
    {
        XmlNode Node_Status = CreateNode("Status", ParentNode, "");
        CreateNode("Text", Node_Status, Text);
    }
    
    public void CreateComments(string Comments, XmlNode ParentNode)
    {
        XmlComment headerComments = doc.CreateComment(Environment.NewLine +
        "********************************************************" + Environment.NewLine +
            Comments + Environment.NewLine +
        "********************************************************" + Environment.NewLine);
        ParentNode.AppendChild(headerComments);
    }
    
    public void CreateSimpleComments(string Comments, XmlNode ParentNode)
    {
        XmlComment headerComments = doc.CreateComment(Comments);
        ParentNode.AppendChild(headerComments);
    }
    
    public void SaveCCR_File()
    {
        string FileName = "CCR";

        string DirectoryPath = RootPath + "/CCR/Files";

        if (!Directory.Exists(DirectoryPath))
        {
            Directory.CreateDirectory(DirectoryPath);
        }

        doc.Save(DirectoryPath + "/" + FileName + ".xml");
    }
}