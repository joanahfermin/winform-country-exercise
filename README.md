# winform-country-exercise
 A simple WinForm application that lists contents of a single table, and has the ability to add new rows

# Overview
This is a sample exercise I created while learning how to perform simple database operation using C# Winforms.  The contents of the table is retrieved on startup of the application.  The user can also add new rows by supplying the country name from the textbox and clicking the Add button.

![alt text](https://github.com/joanahfermin/winform-country-exercise/blob/main/screenshot.png?raw=true)

# How to run the application

- Connect to your SQL client and create the table.  The script to create the table can be found in createtable.sql
- Go to DButil.cs and modify the CONNECTION_STRING constant to suit your own setup.
