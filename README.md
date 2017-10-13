Viagogo Coding Challenge
------------------------

This project was developed for Viagogo Coding Challenge using C# using Visual Studio 2017

## Building & running the code.

Code for the project can be found below.

> https://github.com/DileepMardham/Viagogo

Please use "Clone or download" button to download the whole project to your local machine and extract it.

Once done, open the .sln file with Visual Studio. Build and run the code using Visual Studio.

If you do not have Visual Studio, go to the following path in the extracted folder. This folder has 2 files, an executable file and a configuration file.

> Viagogo-master\Executable

Double-click on the 'Viagogo' executable application file. This will run the program. You can change the configuration settings in the 'Viagogo.exe.config' if you want using any text editor. You need to change values and save the configuration file before you run the application.

### Assumptions Made

1. Number of events at a location ranges from 1-2. The requirement was to have only one event at a location, but I coded the program to handle multiple events at a single location.
2. Number of tickets for one event is between 0 and 500.
3. Price range for any ticket is between 10 and 2000 US dollars
4. Added all the world ranges to the App.config file to make project more dynamic and manageble.
5. Every event Id is a unique 6 digit number. The first 3 digits are the location number and the last 3 digits are the event number itself.

### How might you change your program if you needed to support multiple events at the same location?

Each location in my application can support multiple events. The Min and Max for the number of events has to be set in the configuration file. To support multiple events, I simply used a list of events in the location class rather than having just a single event object as a property. And I modified all the other code used to search and display events at the 5 closest locations along with event informatio.

### How would you change your program if you were working with a much larger world size?

Right now my program will support any world size as I am using a configuration file. If I develop a website or an application I would create a database to hold all the information and create a map of the world to show on the app or the website. We should ideally create an API that will interact with the database as well.

We can show the event location on the map when the user searches events near a location. We can improve searching algorithms to increase performance as there will be more data to handle in a larger world. In a real world scenario, we should look at graphs to search and find nearst events.









