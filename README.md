# BA-SE-ST200 - Dynamics 365 integration with 3rd Party API's using Azure Web Job, Logic Apps, Function & PowerApps

Welcome to the BA-SE-ST200 wiki! This page will show you all the steps that are required to complete the lab. Let's get started.

Here are the steps you need to follow for this lab:

## 1. Integration Use Case using WebJobs.

* Login to Azure and Create a new Service Bus.
* Navigate to created Service Bus, then go to Shared Access Policies form left panel.
* Select RootManageSharedAccessKey, and copy the value of Primary Connection String.
* In Service Bus Explorer, go to File -> Connect. Enter your connection string and click on Ok button.
* From Left Navigation, right click on Topics and select Create Topic. Give your topic a name and click on Create.
* Right click on newly created topic, and select Create Subscription. Give your subscription a name and click on Create.
* Login to your Dynamics 365 CE instance on Plugin Registration Tool.
* Go to Register -> Register New Service Endpoint
* Paste your Service Bus Connection string in the popup and click on Next
* In the next Popup, select Destination Type as Topic, Topic Name should be the new topic name that you just created, Message Format as JSON, leave remaining field as is and click on Save.
* Now right click on the Service Endpoint you just registered, and go to Register New Step
* Select Message as Create, Primary Entity as Contact, Execution Mode as Asynchronous, leave remaining fields as is and click on Register New Step button.
* Now we will create an Azure Function that will listen to the Service Bus topic, and send the message to External Web API (in our case, RequestBin API)
* Go to Visual Studio 2017, click on Create New Project
* From Cloud Templates, select Azure WebJob and click OK.
* Install this Nuget Package on your WebJob project:

`Microsoft.Azure.WebJobs.ServiceBus`

* Go to App.Config file, in the Connection Strings section, add a new key for storing Azure Connection String for Service Bus:

`<add name="AzureWebJobsServiceBus" connectionString="Paste-Your-Service-Bus-Connection-String-Here"/> <!--TODO-->`

* For AzureWebJobsDashboard and AzureWebJobsStorage keys, set the connectionString value to `UseDevelopmentStorage=true`

* Add a class named Contact, and paste the code from https://github.com/crazyLearning/BA-SE-ST200/tree/master/FunctionApp3/Microsoft.Dynamics365.Integrations.WebJob
* Add a class named RootObject and paste code from https://github.com/crazyLearning/BA-SE-ST200/tree/master/FunctionApp3/Microsoft.Dynamics365.Integrations.WebJob
* Update the class Program.cs using code from https://github.com/crazyLearning/BA-SE-ST200/tree/master/FunctionApp3/Microsoft.Dynamics365.Integrations.WebJob
* Update the class Function.cs using code from https://github.com/crazyLearning/BA-SE-ST200/tree/master/FunctionApp3/Microsoft.Dynamics365.Integrations.WebJob
* Once all classes are set, run the Function by pressing F5


![](https://github.com/crazyLearning/BA-SA-ST204/blob/master/images/Screenshot%20(321).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(539).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(540).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(541).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(542).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(531).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(532).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(533).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(534).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(535).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(536).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(537).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(538).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(498).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(499).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(500).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(511).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(502).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(503).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(512).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(513).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(514).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(515).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(516).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(543).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(546).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(547).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(548).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(549).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(550).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(545).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(530).png)

## 2. Integration Use Case using Azure Functions.

* Login to Azure and Create a new Service Bus.
* Navigate to created Service Bus, then go to Shared Access Policies form left panel.
* Select RootManageSharedAccessKey, and copy the value of Primary Connection String.
* In Service Bus Explorer, go to File -> Connect. Enter your connection string and click on Ok button.
* From Left Navigation, right click on Topics and select Create Topic. Give your topic a name and click on Create.
* Right click on newly created topic, and select Create Subscription. Give your subscription a name and click on Create.
* Login to your Dynamics 365 CE instance on Plugin Registration Tool.
* Go to Register -> Register New Service Endpoint
* Paste your Service Bus Connection string in the popup and click on Next
* In the next Popup, select Destination Type as Topic, Topic Name should be the new topic name that you just created, Message Format as JSON, leave remaining field as is and click on Save.
* Now right click on the Service Endpoint you just registered, and go to Register New Step
* Select Message as Create, Primary Entity as Contact, Execution Mode as Asynchronous, leave remaining fields as is and click on Register New Step button.
* Now we will create an Azure Function that will listen to the Service Bus topic, and send the message to External Web API (in our case, RequestBin API)
* Go to Visual Studio 2017, click on Create New Project
* From Cloud Templates, select Azure Function and click OK.
* Give your Topic, Subscription name, and a friendly name to your Connection String property then click on OK.
* Go to localsettings.json, add a new key for storing Azure Connection String for Service Bus.
* Add a class named Contact, and paste the code from https://github.com/crazyLearning/BA-SE-ST200/tree/master/FunctionApp3/FunctionApp3
* Add a class named RootObject and paste code from https://github.com/crazyLearning/BA-SE-ST200/tree/master/FunctionApp3/FunctionApp3
* You can even copy-paste Function class code from https://github.com/crazyLearning/BA-SE-ST200/tree/master/FunctionApp3/FunctionApp3
* Once all classes are set, run the Function by pressing F5


![](https://github.com/crazyLearning/BA-SA-ST204/blob/master/images/Screenshot%20(321).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(539).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(540).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(541).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(542).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(531).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(532).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(533).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(534).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(535).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(536).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(537).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(538).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(498).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(499).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(500).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(511).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(502).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(503).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(512).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(513).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(514).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(515).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(516).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(517).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(518).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(519).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(520).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(521).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(522).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(523).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(525).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(526).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(527).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(528).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(529).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(530).png)


## 3. Integration Use Case using Logic Apps.

* Logic to Azure Portal and Create a new Logic App.
* Add a new trigger, select Dynamics 365 and then select When a record is created.
* Click on Sign In and login to your Dynamics 365 CE instance.
* Select your organization and then select Contacts in Entity Name field.
* Update the Interval to 1 minute.
* Add a new step and select HTTP.
* Navigate to https://requestbin.fullcontact.com and click on Create a Request Bin button.
* Copy the Bin URL, and paste it into URL field of HTTP step in your Logic App.
* In Body, paste this JSON:

`"{ 'FirstName':'', 'LastName':'', 'JobTitle':'', 'BusinessPhone':'', 'MobilePhone':'', 'Email':'', 'Description':'', }"`

* For each of the Keys in the JSON, add the respective fields from DYnamics 365 CE in Dynamic Content popup.
* Save the Logic App.

![](https://github.com/crazyLearning/BA-SA-ST204/blob/master/images/Screenshot%20(321).png)
![](https://github.com/crazyLearning/BA-SA-ST204/blob/master/images/Screenshot%20(331).png)
![](https://github.com/crazyLearning/BA-SA-ST204/blob/master/images/Screenshot%20(332).png)
![](https://github.com/crazyLearning/BA-SA-ST204/blob/master/images/Screenshot%20(333).png)
![](https://github.com/crazyLearning/BA-SA-ST204/blob/master/images/Screenshot%20(334).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(483).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(484).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(486).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(485).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(487).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(488).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(489).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(490).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(493).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(494).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(495).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(496).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(497).png)


## 4. Integration Use Case using PowerApps

* Navigate to your Dynamics 365 CE instance.
* In the same browser, open a new tab and go to https://powerapps.microsoft.com/en-us/
* Click on Sign In, you will be automatically signed in using your CRM credentials.
* Create a new App, select Blank App from templates.
* From File Menu, go to Screen Size + orientation and select Portrait orientation, and click on Apply.
* Navigate back to your PowerApp Canvas, and then design the form as shown in screenshot. We need 7 text input fields and 1 button.
* For all text fields, go to properties, and clear Default Input text, and provide meaningful Hint Texts for all of them.
* Click on Button, and Rename it. Then Go to Action Menu and click on Flow.
* Click on Create new Flow.
* Click on New Step, add Create Record action from Dynamics 365.
* Select Organization instance, Entity Name as Contact, and for Last Name, Business Phone, Description, Email, First Name, Job Title, Mobile Phone fields, select value as Ask in PowerApps from Dynamic Content popup.
* Add a new step and select HTTP from available options
* Open a new tab and go to https://requestbin.fullcontact.com/
* Click on Create a Request Bin button
* Copy the Bin URL, and paste it in Flow in the URL field of HTTP step.
* For Body, paste this JSON, and add their respective values from the values that we added for fields in Dynamics 365 Create record step.

`"{
'FirstName':'',
'LastName':'',
'JobTitle':'',
'BusinessPhone':'',
'MobilePhone':'',
'Email':'',
'Description':'',
}"`

* Save the Flow and go back to your PowerApp tab.
* Now we need to set the OnSelect Property of our button to text shown below. Make sure that the parameters are ordered properly as per the Flow.
* Go to File -> Save As. Give your PowerApp a name and save it.


`'PowerAppsbutton-2'.Run(TextInput1_1.Text, TextInput1_3.Text, TextInput1_6.Text, TextInput1_5.Text, TextInput1.Text, TextInput1_2.Text, TextInput1_4.Text)`




![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(457).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(458).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(459).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(462).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(463).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(464).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(465).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(466).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(467).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(468).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(469).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(470).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(471).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(480).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(472).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(473).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(475).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(477).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(478).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(479).png)
![](https://github.com/crazyLearning/BA-SE-ST200/blob/master/images/Screenshot%20(476).png)
