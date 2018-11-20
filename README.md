# E-Invoice Simple

# E-Invoicing Deployment diagram 
![capture](https://user-images.githubusercontent.com/24559824/48752184-9a346f80-ecba-11e8-8891-d2f0906e47c6.PNG)


## Demo E-invoice : Mobile App , Windows Form App

## Mobile App :
* Mobile apps using JavaScript and React
* Framework : react-native 
* Library : react-native-firebase , react-navigation .
### Feature
* Insert necessary information to SEND
* SEND Customer,Invoice,Company,Items Information ,  to Web Database server(firebase) use react-native-firebase .
### HOW TO USE
* Create project(1) on Firebase 
* Get google-services.json from project(1)
* Change google-services.json at \demoEInvoicingMobile\android\app 
* CMD in root project : react-native run-android 
* Done !

![capture](https://user-images.githubusercontent.com/24559824/48751762-aa4b4f80-ecb8-11e8-93f4-afebda12239e.PNG)
![capture1](https://user-images.githubusercontent.com/24559824/48751781-bb945c00-ecb8-11e8-9244-67477463fd17.PNG)
![capture2](https://user-images.githubusercontent.com/24559824/48751783-bc2cf280-ecb8-11e8-8430-20cf2aa9c14e.PNG)

## Windows Form App 
* Windows Form Apps using C# 
* Packages : FireSharp.1.1.0 , FireSharp.Serialization.JsonNet.1.1.0 , Newtonsoft.Json.7.0.1 , sautinsoft.document.3.5.9.26 ,RestSharp.104.4.0
### Feature
* GET Customer,Invoice,Company,Items Information from Web Database server(firebase) use FireSharp . 
* Load Data to DataGridView
* Save data to Database use SQLSERVER
* Create PDF File to Print Invoice
### HOW TO USE
* Run demoEInvoicing.sql to create Database 
* Open visual studio 2015 and RUN !

![demoapp](https://user-images.githubusercontent.com/24559824/48751906-70c71400-ecb9-11e8-8408-69423e6199f0.png)
![2](https://user-images.githubusercontent.com/24559824/48751908-715faa80-ecb9-11e8-88f5-3ffac4c87fe2.PNG)

