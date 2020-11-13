
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace FrontEndSD
{
    class Database
    {
        // Declare variables
        private string connString, myQuery = "";
        private bool connectFail = false;
        private DateTime today, showStart, showEnd;

        private List<List<object>> table = new List<List<object>>();
        private List<object> row = new List<object>();


        /* Connect to Database */
        private OleDbConnection GetConnection()
        {
            connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=I:\FrontEndSD\FrontEndSD\UserDatabase.mdb";  // Path to database
            return new OleDbConnection(connString); //returns path
        }




        /* ===== INSERT COMMANDS ===== */

        /* Creates a new Account */
        private void InsertAccount(string userName, string password, bool isStaff)
        {
            // Inserts a new Account into the Account table
            myQuery = "INSERT INTO Account ( [UserName] , [Passwords] , [Staff] ) VALUES ( '" + userName + "' , '" + password + "' , " + isStaff + " )";  // Boolean doesn't have to be capitalised
            RunCommand(myQuery);
        }


        /* Creates a new Sustomer */
        public void InsertCustomer(string userName, string password, string firstName, string lastName, string email, string address, string postCode, DateTime dateOfBirth)
        {
            // Create an account
            InsertAccount(userName, password, false);


            // Retreives AccountID from Account table
            myQuery = "SELECT AccountID FROM Account WHERE UserName='" + userName + "' AND Passwords='" + password + "'";
            int accountID = Convert.ToInt32(GetFieldData(GetTableData(myQuery)));


            string customerNo = accountID.GetHashCode().ToString().Replace(@"-", ""); // Creates customerNo off of accountID


            // Inserts new Customer into the Customer table
            myQuery = "INSERT INTO Customer ( [AccountID] , [RegUserNo] , [FirstName] , [LastName] , [Email] , [Address] , [PostCode] , [DOB] ) VALUES ( '" + accountID + "' , '" + customerNo + "' , '" + firstName + "' , '" + lastName + "' , '" + email + "' , '" + address + "' , '" + postCode + "' , '" + dateOfBirth + "' )";
            RunCommand(myQuery);
        }


        /* Creates a new Performance */
        public void InsertPerformance(int showID, double cost, DateTime time)
        {
            // Inserts a new Performance into the Performance table
            myQuery = "INSERT INTO Performance ( [ShowID] , [Cost] , [Dates] ) VALUES ( '" + showID + "' , '" + cost + "' , '" + time + "' )";
            RunCommand(myQuery);
        }


        /* Creates a new PerformanceSeat */
        public void InsertPerformanceSeat(int performanceID, int seatID)
        {
            // Insert a new PerformanceSeat into the PerformanceSeat table
            myQuery = "INSERT INTO PerformanceSeat ( [PerformanceID] , [SeatID] , [SeatAvailable] ) VALUES ( '" + performanceID + "' , '" + seatID + "' , " + false + " )";
            RunCommand(myQuery);
        }


        /* Creates a new Review */
        public void InsertReview(int accountID, int showID, string review, int reviewRating)
        {
            // Inserts a new Review into the Review table
            myQuery = "INSERT INTO Review( [AccountID] , [ShowID] , [Review] , [DateTime] , [ReviewRating] ) VALUES ( '" + accountID + "' , '" + showID + "' , '" + review + "' , '" + today + "' , '" + reviewRating + "' )";
            RunCommand(myQuery);
        }


        /* Creates a new Show */
        public void InsertShow(string showName, DateTime startDate, DateTime endDate, string genre, string description, string imgAddress)
        {
            // Inserts a new Show into the Show table
            myQuery = "INSERT INTO Show ( [ShowName] , [StartDate] , [EndDate] , [Genre] , [OverallRating] , [Description] , [ImgAddress] ) VALUES ( '" + showName + "' , '" + startDate + "' , '" + endDate + "' , '" + genre + "' , '0' , '" + description + "' , '" + imgAddress + "' )";
            RunCommand(myQuery);
        }


        /* Creates a new Staff */
        public void InsertStaff(string userName, string password, string firstName, string lastName, string email, string address, string postCode, DateTime dateOfBirth)
        {
            // Creates an Account 
            InsertAccount(userName, password, true);


            // Gets AccountID for new Account
            myQuery = "SELECT AccountID FROM Account WHERE UserName='" + userName + "' AND Passwords='" + password + "'";
            int accountID = Convert.ToInt32(GetFieldData(GetTableData(myQuery)));


            string staffNo = accountID.GetHashCode().ToString().Replace(@"-", "");  // Creates staffNo from the accountID


            // Inserts a new Staff into the Staff table
            myQuery = "INSERT INTO Staff ( [AccountID] , [StaffNo] , [FirstName] , [LastName] , [Email] , [Address] , [PostCode] , [DOB] ) VALUES ( '" + accountID + "' , '" + staffNo + "' , '" + firstName + "' , '" + lastName + "' , '" + email + "' , '" + address + "' , '" + postCode + "' , '" + dateOfBirth + "' )";
            RunCommand(myQuery);
        }


        /* Creates a new Ticket */
        public void InsertTicket(int accountID, int performanceID, int seatID, double totalCost, bool deliver)
        {
            // Inserts a new Ticket into the Ticket Table 
            myQuery = "INSERT INTO Ticket ( [AccountsID] , [PerformanceID] , [SeatID] , [TotalCost] , [Deliver] ) VALUES ( " + accountID + " , " + performanceID + " , " + seatID + " , " + totalCost + " , " + deliver + " )";
            RunCommand(myQuery);
        }

        


        /* ===== SELECT COMMANDS ====== */

        /* Checks whether the login is sucessful */
        public User LoginCheck(string username, string password)
        {
            // Declare variables
            List<object> joinedRow;


            // Check if UserName and Password match database
            myQuery = "SELECT AccountID, UserName, Passwords, Staff, Admin FROM Account WHERE UserName='" + username + "' AND Passwords='" + password + "' AND Deleted=false";
            row = GetRowData(GetTableData(myQuery));


            // Depending on SQL, the return displays whether user can login or not
            if (row.Count == 0) // If no match
                return null;
            else // If account found
            {
                // Set variables
                int accountID = Convert.ToInt32(row.ElementAt(0));
                bool isStaff = Boolean.Parse(row.ElementAt(3).ToString());
                bool isAdmin = Boolean.Parse(row.ElementAt(4).ToString());


                // Decides which values are need for the SQL to get the rest of the account's data
                string accountSQL = "";
                string accountType = "";
                if (isStaff) // If account is staff
                {
                    accountType = "Staff";
                    accountSQL = "StaffNo, FirstName, LastName, Email, Address, PostCode, DOB";
                }
                else if (isAdmin) // If account is an admin
                {
                    accountType = "Admin";
                    accountSQL = "AdminNo";
                }
                else // If account is a customer
                {
                    accountType = "Customer";
                    accountSQL = "RegUserNo, FirstName, LastName, Email, Address, PostCode, DOB";
                }


                // Gets rest of accounts details
                myQuery = "SELECT " + accountSQL + " FROM " + accountType + " WHERE AccountID=" + accountID;
                List<object> userType = GetRowData(GetTableData(myQuery));
                

                joinedRow = JoinRows(row, userType); // Joins both lists together


                // Creates an user and then returns it
                if (isAdmin) // If user is an admin
                    return new Admin(Convert.ToInt32(joinedRow[0]), joinedRow[5].ToString(), joinedRow[1].ToString(), joinedRow[2].ToString());
                else // If user is not an admin
                    return new Guest(Convert.ToInt32(joinedRow[0]), joinedRow[5].ToString(), joinedRow[1].ToString(), joinedRow[2].ToString(), joinedRow[6].ToString(), joinedRow[7].ToString(), joinedRow[8].ToString(), joinedRow[9].ToString(), joinedRow[10].ToString(), DateTime.Parse(joinedRow[11].ToString()), Boolean.Parse(joinedRow[3].ToString()), Boolean.Parse(joinedRow[4].ToString()), false);
            }
        }
        

        /* Checks whether the username is taken */
        public bool UsernameTaken(string username)
        {
            // Checks if a UserName matches with the database
            myQuery = "SELECT UserName FROM Account WHERE UserName='" + username + "'";
            table = GetTableData(myQuery);


            // Returns true or false depending on whether the field exists or not
            if (table.Count == 0) // Username free
                return false;
            else // Username taken
                return true;
        }


        /* Gets a users Account details */
        public User GetUser(int accountID)
        {
            // Gets account details from account for a user
            myQuery = "SELECT AccountID, UserName, Passwords, Staff, Admin FROM Account WHERE AccountID=" + accountID;
            List<object> account = GetRowData( GetTableData(myQuery) );


            // Creates a new user and returns it
            return new Guest(Convert.ToInt32(account[0]), null, account[1].ToString(), account[2].ToString(), null, null, null, null, null, new DateTime(), Boolean.Parse(account[3].ToString()), Boolean.Parse(account[4].ToString()), false);
        }


        /* Returns all non admin account's data */
        public List<User> GetUsers()
        {
            // Declare variables
            List<object> joinedTable = new List<object>();
            List<object> userType = new List<object>();
            List<User> users = new List<User>();


            // Gets all details from all users in Account
            myQuery = "SELECT AccountID, UserName, Passwords, Staff, Admin, Deleted FROM Account";
            table = GetTableData(myQuery);


            // Depending on SQL, the return displays whether user can login or not
            if (table.Count == 0) // If no accounts 
                return null;
            else // If there are accounts
            {
                // Loop for each row
                foreach (List<object> row in table)
                {
                    // Set variables
                    int accountID = Convert.ToInt32(row.ElementAt(0));
                    bool isStaff = Boolean.Parse(row.ElementAt(3).ToString());
                    bool isAdmin = Boolean.Parse(row.ElementAt(4).ToString());


                    if (!isAdmin) // If not admin
                    {
                        // Declare variables
                        string accountSQL = "";
                        string accountType = "";

                        // Sets value to input into SQL
                        if (isStaff) // If staff
                        {
                            accountType = "Staff";
                            accountSQL = "StaffNo";
                        }
                        else // If customer
                        {
                            accountType = "Customer";
                            accountSQL = "RegUserNo";
                        }

                        
                        // Gets all deta for accounts
                        myQuery = "SELECT " + accountSQL + ", FirstName, LastName, Email, Address, PostCode, DOB FROM " + accountType + " WHERE AccountID=" + accountID;
                        userType = GetRowData(GetTableData(myQuery));
                        
                        joinedTable = JoinRows(row, userType); // Joins rows together

                        // Create new user and add to users list
                        users.Add(new Guest(Convert.ToInt32(joinedTable[0]), joinedTable[6].ToString(), joinedTable[1].ToString(), joinedTable[2].ToString(), joinedTable[7].ToString(), joinedTable[8].ToString(), joinedTable[9].ToString(), joinedTable[10].ToString(), joinedTable[11].ToString(), DateTime.Parse(joinedTable[12].ToString()), Boolean.Parse(joinedTable[3].ToString()), Boolean.Parse(joinedTable[4].ToString()), Boolean.Parse(joinedTable[5].ToString())));
                        
                    }
                }
            }

            return users;
        }


        /* Checks if a seat is free */
        public bool SeatFree(int performanceID, int seatID)
        {
            // Gets SeatID from PerformanceSeat
            myQuery = "SELECT SeatID FROM PerformanceSeat WHERE PerformanceID=" + performanceID;
            table = GetTableData(myQuery);


            // Loops for each row
            foreach (List<object> row in table)
            {
                if (Convert.ToInt32(row.ElementAt(0)) == seatID) // If element 0 (SeatID) and seatID match
                    return false; // Seat taken, returns false
            }

            return true; // No match, return true
        }


        /* Gets the cost of a BandSeat */
        public double BandCost(char band)
        {
            // Select everything from BandSeat for a band
            myQuery = "SELECT BandID, Type, Cost FROM BandSeat WHERE Type='" + band + "'";
            double bandCost = Double.Parse(GetFieldData(GetTableData(myQuery)).ToString());

            return bandCost;
        }


        /* Gets all shows */
        public List<Show> GetShows()
        {
            // Declare variable
            List<Show> shows = new List<Show>();


            // Selects all columns from Show and sort assendingly
            myQuery = "SELECT ShowID, ShowName, StartDate, EndDate, Genre, OverallRating, Description, ImgAddress, Cancelled FROM Show ORDER BY ShowName ASC";
            table = GetTableData(myQuery);


            // Loops for each row and create a new show then add to shows list
            foreach (List<object> row in table)
                shows.Add(new Show(Int32.Parse(row.ElementAt(0).ToString()), row.ElementAt(1).ToString(), row.ElementAt(4).ToString(), DateTime.Parse(row.ElementAt(2).ToString()), DateTime.Parse(row.ElementAt(3).ToString()), row.ElementAt(6).ToString(), row.ElementAt(7).ToString(), Convert.ToInt32(Double.Parse(row.ElementAt(5).ToString())), Boolean.Parse(row.ElementAt(8).ToString())));
            

            return shows;
        }


        /* Gets shows currently being performed */
        public List<Show> GetCurrentShows()
        {
            // Declare variable
            List<Show> shows = new List<Show>();


            // Selects all data from Show order assendingly by ShowName
            myQuery = "SELECT ShowID, ShowName, StartDate, EndDate, Genre, OverallRating, Description, ImgAddress FROM Show ORDER BY ShowName ASC";
            table = GetTableData(myQuery);


            // Loop for each row
            foreach (List<object> row in table)
            {
                // Sets variables
                today = DateTime.Now;
                showStart = DateTime.Parse(row.ElementAt(2).ToString());
                showEnd = DateTime.Parse(row.ElementAt(3).ToString());

                // Checks show is current being performed and creates a new show then adds to shows list
                if (today >= showStart && today <= showEnd) // If showStart was before today and showEnd is after today
                    shows.Add( new Show(Convert.ToInt32(row.ElementAt(0)), row.ElementAt(1).ToString(), row.ElementAt(4).ToString(), showStart, showEnd, row.ElementAt(6).ToString(), row.ElementAt(7).ToString(), Convert.ToInt32( Double.Parse(row.ElementAt(5).ToString()) )) );
            }

            return shows;
        }
        

        /* Gets all performances for a show */
        public List<Show> GetAllPerformances(int showID)
        {
            // Declare variable
            List<Show> shows = new List<Show>();


            // Selects all field for performances for a show
            myQuery = "SELECT PerformanceID , ShowID , Dates , Cost , Cancelled FROM Performance WHERE ShowID=" + showID;
            table = GetTableData(myQuery);


            // Loops for each row and create a new show then add to shows list
            foreach (List<object> row in table)
                shows.Add( new Show(Convert.ToInt32(row.ElementAt(0)), Convert.ToInt32(row.ElementAt(1)), DateTime.Parse(row.ElementAt(2).ToString()), Double.Parse(row.ElementAt(3).ToString()), Boolean.Parse(row.ElementAt(4).ToString())) );
            

            return shows;
        }


        /* Gets all current perfromances */
        public List<Show> GetCurrentPerformances()
        {
            // Declares variables
            List<object> performs = new List<object>();
            List<Show> shows = new List<Show>();

            DateTime date;
            today = DateTime.Now;

            int showID = 0;


            // Selects every performance which hasn't been cancelled and order assendingly by dates
            myQuery = "SELECT PerformanceID , ShowID , Dates , Cost FROM Performance WHERE Cancelled=FALSE ORDER BY Dates ASC";
            table = GetTableData(myQuery);


            // Loops for all rows
            foreach (List<object> row in table)
            {
                // Set variables
                showID = Convert.ToInt32(row.ElementAt(1));
                date = DateTime.Parse(row.ElementAt(2).ToString());

                // Checks performance hasn't been shown 
                if (today <= date) // If today is before date
                {
                    // Selects one show where ShowID matchs showID 
                    myQuery = "SELECT ShowName , StartDate , EndDate , Genre , Description , ImgAddress , OverallRating FROM Show WHERE ShowID=" + showID;
                    performs = GetRowData(GetTableData(myQuery));

                    // Creates a show and adds it to shows list
                    shows.Add( new Show(Convert.ToInt32(row.ElementAt(0)), Convert.ToInt32(row.ElementAt(1)), performs.ElementAt(0).ToString(), performs.ElementAt(3).ToString(), DateTime.Parse(row.ElementAt(2).ToString()), DateTime.Parse(performs.ElementAt(1).ToString()), DateTime.Parse(performs.ElementAt(2).ToString()), Double.Parse(row.ElementAt(3).ToString()), performs.ElementAt(4).ToString(), performs.ElementAt(5).ToString(), Convert.ToInt32( Double.Parse(performs.ElementAt(6).ToString()) )) ); 
                }
            }

            return shows;
        }


        /* Gets all current performances for a show */
        public List<Show> GetCurrentPerformances(int showID)
        {
            // Declare variables
            List<Show> shows = new List<Show>();
            DateTime dates;
            today = DateTime.Now;


            // Selects performances for a show where not cancelled and order assendingly by dates
            myQuery = "SELECT PerformanceID , ShowID , Dates , Cost FROM Performance WHERE Cancelled=FALSE AND ShowID=" + showID + " ORDER BY Dates ASC";
            table = GetTableData(myQuery);


            // Loops for each row
            foreach (List<object> row in table)
            {
                // Set variable
                dates = DateTime.Parse(row.ElementAt(2).ToString());

                // When performance hasn't been shown yet, create a new show and add to shows list
                if (today < dates) // If date is later than today
                    shows.Add( new Show(Convert.ToInt32(row.ElementAt(0)), Convert.ToInt32(row.ElementAt(1)), dates, Double.Parse(row.ElementAt(3).ToString()), false) );
            }

            return shows;
        }


        /* Gets top rated shows  */
        public List<Show> GetTopShows()
        {
            // Declares variables
            List<Show> topShows = new List<Show>();

            today = DateTime.Now;
            showStart = new DateTime();
            showEnd = new DateTime();

            int topShowSpace = 4;


            // Selects all shows which aren't cancelled and order assendingly by OverallRating
            myQuery = "SELECT ShowID, ShowName , StartDate , EndDate , Genre , Description , ImgAddress , OverallRating FROM Show WHERE Cancelled=FALSE ORDER BY OverallRating DESC";
            table = GetTableData(myQuery);


            // Loops for all rows
            foreach (List<object> row in table)
            {
                // Set variables
                showStart = DateTime.Parse(row.ElementAt(2).ToString());
                showEnd = DateTime.Parse(row.ElementAt(3).ToString());

                // Checks show is current being performed 
                if (today >= showStart && today <= showEnd) // If showStart was before today and showEnd is after today
                {
                    // Space left to display show
                    if (topShowSpace != 0)
                    {
                        topShows.Add( new Show(Convert.ToInt32(row.ElementAt(0)), row.ElementAt(1).ToString(), row.ElementAt(4).ToString(), showStart, showEnd, row.ElementAt(5).ToString(), row.ElementAt(6).ToString(), Convert.ToInt32( Double.Parse(row.ElementAt(7).ToString()) )) );
                        topShowSpace--; // Decrement counter
                    }
                    else // No space left
                        break;
                }
            }

            return topShows;
        }


        /* Gets future shows */
        public List<Show> GetComingSoonShows()
        {
            // Declares variables
            List<Show> shows = new List<Show>();

            today = DateTime.Now;


            // Select all shows which aren't cancelled order assendingly by StartDate
            myQuery = "SELECT ShowID, ShowName , StartDate , EndDate , Genre , Description , ImgAddress , OverallRating FROM Show WHERE Cancelled=FALSE ORDER BY StartDate ASC";
            table = GetTableData(myQuery);


            // Loops for all shows
            foreach (List<object> rows in table)
            {
                // Set variables
                showStart = DateTime.Parse(rows.ElementAt(2).ToString());

                // Checks that show hasn't started and create a new show then add to shows list
                if (today < showStart) // If showStart is after today
                    shows.Add( new Show(Convert.ToInt32(rows.ElementAt(0)), rows.ElementAt(1).ToString(), rows.ElementAt(4).ToString(), showStart, DateTime.Parse(rows.ElementAt(3).ToString()), rows.ElementAt(5).ToString(), rows.ElementAt(6).ToString(), Convert.ToInt32(rows.ElementAt(7))) );
            }

            return shows;
        }

        
        /* Get reviews */
        public List<Review> GetReviews(int showID, bool showAll)
        {
            // Declare variables
            List<Review> showReviews = new List<Review>();


            // Selects reviews for a show
            if (showAll) // Show all shows
                myQuery = "SELECT ReviewID, ShowID, AccountID, Review, DateTime, ReviewRating, Deleted FROM Review WHERE ShowID=" + showID;
            else // Don't show deleted shows
                myQuery = "SELECT ReviewID, ShowID, AccountID, Review, DateTime, ReviewRating, Deleted FROM Review WHERE Deleted=FALSE AND ShowID=" + showID;

            table = GetTableData(myQuery);


            // Loops for each row and create a new review then add to showReviews list
            foreach (List<object> row in table)
                showReviews.Add(new Review(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]), row[3].ToString(), DateTime.Parse(row[4].ToString()), Int32.Parse(row[5].ToString()), Boolean.Parse(row[6].ToString())) );
            

            return showReviews;
        }




        /* ===== UPDATE COMMANDS ===== */

        /* Updates Account table */
        public void UpdateAccount(int accountID, string userName, string password, string firstName, string lastName, string email, string address, string postCode, DateTime dateOfBirth)
        {
            // Updates Account table 
            myQuery = "UPDATE Account SET UserName='" + userName + "', Passwords='" + password + "' WHERE AccountID=" + accountID;
            RunCommand(myQuery);


            // Gets Staff from Account
            myQuery = "SELECT Staff FROM Account WHERE AccountID=" + accountID;
            bool isStaff = Boolean.Parse(GetFieldData(GetTableData(myQuery)).ToString());


            // Sorts what table to update data
            string accountType = "";
            if (isStaff) // If staff
                accountType = "Staff";
            else  // If customer
                accountType = "Customer";


            // Updates table
            myQuery = "UPDATE " + accountType + " SET FirstName='" + firstName + "', LastName='" + lastName + "', Email='" + email + "', Address='" + address + "', PostCode='" + postCode + "', DOB='" + dateOfBirth + "' WHERE AccountID=" + accountID;
            RunCommand(myQuery);
        }


        /* Deletes Account */
        public void DeleteAccount(int accountID, bool delete)
        {
            // Updates Deleted checkbox in Account table
            myQuery = "UPDATE Account SET Deleted=" + delete + " WHERE AccountID=" + accountID;
            RunCommand(myQuery);
        }


        /* Updats Shows' table data */
        public void UpdateShow(int showID, string showName, DateTime startDate, DateTime endDate, string genre, string description, string imgAddress)
        {
            // Updates Show table
            myQuery = "UPDATE Show SET ShowName='" + showName + "', StartDate='" + startDate + "', EndDate='" + endDate + "', Genre='" + genre + "', Description='" + description + "', ImgAddress='" + imgAddress + "' WHERE ShowID=" + showID;
            RunCommand(myQuery);
        }


        /* Cancels a show */
        public void CancelShow(int showID, bool cancel)
        {
            // Updates Cancelled checkbox in Show Table
            myQuery = "UPDATE Show SET Cancelled=" + cancel + " WHERE ShowID=" + showID;
            RunCommand(myQuery);
        }


        /* Updates Performance's table data */
        public void UpdatePerformance(int performanceID, int showID, double cost, DateTime time)
        {
            // Updates Performance table
            myQuery = "UPDATE Performance SET ShowID=" + showID + ", Cost='" + cost + "', Times='" + time + "' WHERE PerformanceID=" + performanceID;
            RunCommand(myQuery);
        }


        /* Cancels a performance */
        public void CancelPerformance(int performanceID, bool cancel)
        {
            // Updates Cancelled checkbox in Performance Table
            myQuery = "UPDATE Performance SET Cancelled=" + cancel + " WHERE PerformanceID=" + performanceID;
            RunCommand(myQuery);
        }


        /* Updates reviews */
        public void UpdateReview(Review review, string userReview, int rating)
        {
            // Updates a review within the review table
            myQuery = "UPDATE Review SET Review='" + userReview + "' , ReviewRating=" + rating + " WHERE ReviewID=" + review.ReviewID;
            RunCommand(myQuery);

            UpdateAverageScores(review.ShowID); // Updates average scores
        } 


        /* Updates total scores */
        public void UpdateAverageScores(int showID)
        {
            // Declare variables
            List<List<object>> ratings = new List<List<object>>();
            int performanceID = 0, count = 0;
            double totalScore = 0;


            // Gets all IDs for every Performance of a Show 
            myQuery = "SELECT PerformanceID FROM Performance WHERE ShowID=" + showID;
            List<List<object>> performances = GetTableData(myQuery);
            
            
            // Loop for each row1
            foreach (List<object> row1 in performances)
            {
                // Loop for each field1
                foreach (var field1 in row1)
                {
                    // Sets variable
                    performanceID = Convert.ToInt32(field1);


                    // Gets every ReviewRating for a Performance
                    myQuery = "SELECT ReviewRating FROM Review WHERE PerformanceID=" + performanceID;
                    ratings = GetTableData(myQuery);


                    // Loop for each row2
                    foreach (List<object> row2 in ratings)
                    {
                        // Loop for each field2
                        foreach (var field2 in row2)
                        {
                            // Counts the total number of shows and adds the ratings together
                            totalScore += Double.Parse(field2.ToString());
                            count++;
                        }
                    }
                }
            }


            // Calculates the mean rating score
            double meanScore = 0;
            if (count != 0) // If there are shows
                meanScore = totalScore / count;


            // Updates the OverallRatings in Show
            myQuery = "UPDATE Show SET OverallRating='" + meanScore + "' WHERE ShowID=" + showID;
            RunCommand(myQuery);
        }


        /* Deletes a review */
        public void DeleteReview(int reviewID, bool delete)
        {
            // Updates Deleted checkbox in Review table
            myQuery = "UPDATE Review SET Deleted=" + delete + " WHERE ReviewID=" + reviewID;
            RunCommand(myQuery);
        }

        
        
        
        /* ===== RUN SQL COMMANDS ===== */

        /* Run Command */
        private void RunCommand(string query)
        {
            // Creates connection to the database
            OleDbConnection myConnection = GetConnection();
            OleDbCommand myCommand = new OleDbCommand(query, myConnection);

            try
            {
                // Connects to database and runs SQL
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler" + ex); // Error messages
                MessageBox.Show("You failed to connect to the database.  Please try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Error message
            }
            finally
            {
                myConnection.Close();   // Close connection to database
            }
        }


        /* Gets table data 
         * 
         * Creates a list of a list.  The inner list contains each rows fields.  The outer list contain each row
         */
        private List<List<object>> GetTableData(string query)
        {
            // Declare variable
            List<List<object>> tableData = new List<List<object>>();

            using (OleDbConnection connection = GetConnection())
            {
                // Run command
                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataReader reader = null; 
                
                try
                {
                    connection.Open();                // Opens database connection
                    reader = command.ExecuteReader(); // Reader store SQL results


                    if (reader != null) // If a result
                    {
                        // Loop for every item retrieved from database
                        while (reader.Read())
                        {
                            // Declare variable
                            List<object> rowData = new List<object>();


                            // Loops for every field in reader
                            for (int i = 0; i < reader.FieldCount; i++)
                                rowData.Add(reader[i].ToString());  // Adds each field to rowData


                            tableData.Add(rowData); // Add each row to tableData
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception in DBHandler" + ex); 

                    if (!connectFail) // Message will only once per session, stop mass messaging if within loop
                    {
                        MessageBox.Show("You failed to connect to the database", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); // Error message
                        connectFail = true;
                    }
                }
                finally
                {
                    connection.Close(); // Closes database connection
                }
            }

            return tableData;
        }


        /* Gets row data 
         * 
         * Used only when one row is returned form the SQL query 
         */
        private List<object> GetRowData(List<List<object>> tableData)
        {
            // Declare variable
            List<object> rowData = new List<object>();
            
            // Loop for each row
            foreach (var row in tableData)
            {
                rowData = row;
            }
            
            return rowData;
        }


        /* Gets field data 
         * 
         * Used only when one result is returned from SQL query 
         */
        private object GetFieldData(List<List<object>> tableData)
        {
            // Loops for each row
            foreach (List<object> row in tableData)
            {
                // Loops for each field
                foreach (var field in row)
                {
                    return field; 
                }
            }

            return null;
        }


        /* Joins together the fields from two rows */
        private List<object> JoinRows(List<object> row1, List<object> row2)
        {
            // Loops for each field
            foreach (string field in row2)
            {
                row1.Add(field); // Adds field to row1
            }

            return row1;
        }
    }
}
