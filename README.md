# tenurex-translations

Node-red:
Node-red flow exported as json file, located in root folder "googleTranslateFlow.json" .

* node-red-contrib-google-translate - **does not** support i=from/language.
* node-red-contrib-google-translate-fixed **does** support the abbove but it uses Google service that is not free.
Therefore i used the **first** package as mock service data provider -translations available from all languages to English, **ignoring** the user's input for from/to language.

* Node-red server is listening to** localhost:1880**

MongoDB:
- Mongodb server in initiated by $"mongod --storageEngine inMemory --dbpath C:\data\cache"


.Net Core web api:
Just Build and Run :)

