1.  Use the free open source Admin LTE theme.
   1.1  Create a vertical menu list tree view left sidebar that can handle up to 4 levels of indentation and 24 entries.
   1.2  Clicking on a menu item brings up a web page.
   1.3  Button to hide/view the menu.
   
2.  Use ASP.NET Identity:
   2.1  Use a separate DB context from the AppData.
   2.2  Use a LocalDB SQL Server DB for the Identity tables called SystemTables.
   2.3  Support login, logout, manage account, 2FA, and password reset just like explained in Microsoft's web pages on these subjects for ASP.NET Core 3.1
   2.4  Use Microsoft's QR 2FA Identity approach (see Microsoft's web page how to on/for this).
   2.5  Use a SendGrid free developer account for email sending.
   2.6  If possible, have a working option to use SMS texting via Twilio instead of the QR 2FA.
Allowing user to chose which one to use.
Note:  This may not work as I've read about support problems with this in 3.1.
   2.7  Links in the Admin LTE header for:
Login
Logout
   2.8  Menu folder for Admin in the vertical sidebar menu with entries for:
Login
Logout
Register
Add New User (another user not the current user)
Manage User Account/Settings
3.  Use EF Core to make a very basic To Do/Task List set of pages.
   3.1  Use a separate DB context from Identity.
   3.2  Name the LocalDB database for this called AppData.
   3.3  Create a Tasks table with the following columns:
TaskID int with identity column
TaskDate date
TaskName varchar(80)
TaskDescription varchar(2000)
TaskCompleted bit
   3.4  Create controller and views for:
Create
Delete
Details
Edit
Index
3.5 Add menu entries in the sidebar in #1 above for all 5 views under a Task folder entry.
You can also add some dummy links to one or two dummy web pages as well.
Put this above the Admin entries in #2.8 above.
And simply get it all working together.  No unit tests, no documentation needed.  That's it.

Demo https://todoitp.azurewebsites.net/
