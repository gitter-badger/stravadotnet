stravadotnet
============

Hopefully this small framework makes using the Strava API a little bit easier!
Please keep in mind that this framework is in a pretty early stage and things are about to change.

About this Readme
============

The last couple of weeks i focused on the framework itself, so i haven't had much time to write a Readme file.
In the Program.cs file, you will find a few samples on how to use the framework.


Getting an access token from Strava
============

You can get an access token from Strava by using one of the following methods:

- StaticAuthentication
  You can use this method if you already have an access token. You can either use the WebAuthentication class to get a access token from Strava or you can use your token, that you got when you registered your application.  

  StaticAuthentication auth = new StaticAuthentication("<public token here>");

- WebAuthentication
  This procedure should be used, if you want to authorize your application for the first time. When an object is created and the *GetTokenAsync()* method is invoked, a browser window will open and you have to authorize the apllication. Once the button is clicked, Strava invokes a callback function. When you create a WebAuthentication object, a web server is started locally on your computer. Once the button is clicked, Strava invokes a callback function which is received by the callback server. You now have a working access token created specifically for your application. You can store this access token in a file on your hard disk, so you don't have to open a browser window every time. You should use some sort of cryptographic algorithm, to obfuscate the access token.

Upon the next start of the program, you can then load the token from your hard disk and use the StaticAuthentication method described above.


Hints
--------------

When using the WebAuthentication method in your application, you have to start the application as an admin (at least when you acquire the access token). Strava sends back the access token via a callback. To receive this callback, a WebServer must be started locally. To start such a server, you need admin rights.

After you have received your token, you can save it to a file so you won't have to get a new token every time.

Getting data from Strava
============

Getting data from Strava is pretty straightforward. All you have to do, is to create a *StravaClient* object and pass a valid IAuthenticator object.
  
    StaticAuthentication auth = new StaticAuthentication("token");
    StravaClient client = new StravaClient(auth);
  
Now you can use the *client* object to make some calls to Strava.

As of now, i only have implemented the async methods. "Regular" metods will follow.
Most of the methods are overwritten. When you don't need to pass a parameter to the method, the data will be of the currently authorized athlete.

    //Receive the currently authorized athlete
    Athlete athlete = await client.GetAthleteAsync();
  
When you pass a parameter to the method, you can get data from another athlete.
    
    //Receive an other athlete
    Athlete athlete = await client.GetAthleteAsync("1985994");
    

Feedback
============

If you have any feedback, bug reports or suggestions, feel free to send me an email.
My mail address is bike (at) sascha-simon (dot) com.