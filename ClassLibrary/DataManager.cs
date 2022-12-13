using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace ClassLibrary
{
    public class DataManager
    {
        private static string connectionString = ConfigurationManager.AppSettings["CS"]; 
        public static void setConnectionString()
        {
            ConfigurationManager.AppSettings["CS"] = "server=127.0.0.1;uid=root;database=MiniCasinoJovanovic";
        }

        //Hash methods
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        /// <summary>
        /// Updates a users date of last spin. 
        /// </summary>
        /// <param name="UpdateSpin"></param>
        public static void UpdateLastSpin(DateTime date, int uID)
        {
            string sql = "UPDATE Player SET LastSpin = @date WHERE userID = @userID";

            using (var connection = new MySqlConnection(connectionString))
            {
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        MySqlParameter parameterAmount = new MySqlParameter("@date", date);
                        MySqlParameter parameterUserID = new MySqlParameter("@userID", uID);

                        cmd.Parameters.Add(parameterAmount);
                        cmd.Parameters.Add(parameterUserID);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }

                }
            }

        }

        /// <summary>
        /// Returns time since last spin of set user.
        /// </summary>
        /// <param name="GetDateOfLastSpin"></param>
        public static string GetDateOfLastSpin(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT LastSpin FROM Player WHERE Username = @username", connection);

                MySqlParameter parameterUserID = new MySqlParameter("@username", username);
                cmd.Parameters.Add(parameterUserID);

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        rdr.Read();
                        return Convert.ToString(rdr[0]);
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                }

            }


        }

        /// <summary>
        /// Add to the amount of chips on their hand or in the bank (True == onHand, False == Deposited).
        /// </summary>
        /// <param name="AddToAmountOnHandOrDeposited"></param>
        public static void AddToAmountOnHandOrDeposited(int userID, int amount, bool onHandOrDeposited)
        {
            
            if (onHandOrDeposited == true)  
            {
                string sql = "UPDATE BankAccount SET AmountOnHand = AmountOnHand + @amount WHERE UserID = @userID";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        try
                        {
                            MySqlParameter parameterAmount = new MySqlParameter("@amount", amount);
                            MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);

                            cmd.Parameters.Add(parameterAmount);
                            cmd.Parameters.Add(parameterUserID);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException)
                        {
                            throw new DBException();
                            
                        }

                    }
                }
            }
            else if (onHandOrDeposited == false)
            {
                string sql = "UPDATE BankAccount SET AmountDeposited = AmountDeposited + @amount WHERE UserID = @userID";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        try
                        {
                            MySqlParameter parameterAmount = new MySqlParameter("@amount", amount);
                            MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);

                            cmd.Parameters.Add(parameterAmount);
                            cmd.Parameters.Add(parameterUserID);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException)
                        {

                            throw new DBException();
                        }

                    }
                }
            }

            

        }

        /// <summary>
        /// Remove of the amount of chips on their hand or in the bank (True == onHand, False == Deposited).
        /// </summary>
        /// <param name="removeOfAmountOnHandOrDeposited"></param>
        public static void RemoveOfAmountOnHandOrDeposited(int userID, int amount, bool onHandOrDeposited)
        {

            if (onHandOrDeposited == true)
            {
                string sql = "UPDATE BankAccount SET AmountOnHand = AmountOnHand - @amount WHERE UserID = @userID";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        try
                        {
                            MySqlParameter parameterAmount = new MySqlParameter("@amount", amount);
                            MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);

                            cmd.Parameters.Add(parameterAmount);
                            cmd.Parameters.Add(parameterUserID);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException)
                        {

                            throw new DBException();
                        }

                    }
                }
            }
            else if (onHandOrDeposited == false)
            {
                string sql = "UPDATE BankAccount SET AmountDeposited = AmountDeposited - @amount WHERE UserID = @userID";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (var cmd = new MySqlCommand(sql, connection))
                    {
                        try
                        {
                            MySqlParameter parameterAmount = new MySqlParameter("@amount", amount);
                            MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);

                            cmd.Parameters.Add(parameterAmount);
                            cmd.Parameters.Add(parameterUserID);
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (MySqlException)
                        {

                            throw new DBException();
                        }

                    }
                }
            }



        }



        /// <summary>
        /// Create bank account for new user.
        /// </summary>
        /// <param name="CreateBankAccount"></param>
        public static void CreateBankAccount(int userID)
        {
            //both amounts set on zero, because its only used for new players
            string sql = "INSERT INTO bankaccount (UserID, AmountOnHand, AmountDeposited) VALUES (@UserID, 0, 0)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        MySqlParameter parameterUN = new MySqlParameter("@UserID", userID);

                        cmd.Parameters.Add(parameterUN);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {
                        throw new DBException();
                    }

                }

            }

        }


        /// <summary>
        /// Returns UserID for set username
        /// </summary>
        /// <param name="getUserID"></param>
        /// <returns></returns>
        public static int GetUserID(string username)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT UserID FROM Player WHERE Username = @username", connection);

                MySqlParameter parameterUsername = new MySqlParameter("@username", username);
                cmd.Parameters.Add(parameterUsername);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    return Convert.ToInt32(rdr[0]);
                }
            }
        }

        /// <summary>
        /// Returns Username from set userID
        /// </summary>
        /// <param name="getUsername"></param>
        /// <returns></returns>
        public static string getUsername(int uID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Username FROM Player WHERE UserID = @userID", connection);

                MySqlParameter parameterUsername = new MySqlParameter("@userID", uID);
                cmd.Parameters.Add(parameterUsername);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Read();
                    return Convert.ToString(rdr[0]);
                }
            }
        }

        /// <summary>
        /// Check if user and password combination matches.
        /// </summary>
        /// <param name="CheckPayer"></param>
        public static bool CheckPlayer(string username, string password)
        {
            string hash = GetHashString(password);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {                
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Username, Password FROM Player WHERE Username = @username AND Password = @password", connection);

                MySqlParameter parameterUsername = new MySqlParameter("@username", username);
                MySqlParameter parameterPassword= new MySqlParameter("@password", hash);
                cmd.Parameters.Add(parameterUsername);
                cmd.Parameters.Add(parameterPassword);
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        while (rdr.Read())
                        {
                            string usernameDB = Convert.ToString(rdr[0]);
                            string passwordDB = Convert.ToString(rdr[1]);
                            if (hash == passwordDB)
                            {
                                return true;
                            }
                            else if(usernameDB == null && passwordDB == null)
                            {
                                return false;

                            }

                        }
                        return false;


                    }
                    catch (MySqlException es)
                    {
                        throw new PasswordIncorrectException("Password or Username does not exist", es);
                        
                    }
                    
                }

            }

        }

        /// <summary>
        /// Get the amount of chips spent in a game.
        /// </summary>
        /// <param name="GetExpenditures"></param>
        public static int GetExpenditures(string game)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT SUM(amount) FROM Expenditures WHERE game = @game", connection);

                MySqlParameter parameterUserID = new MySqlParameter("@game", game);
                cmd.Parameters.Add(parameterUserID);

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        rdr.Read();
                        return Convert.ToInt32(rdr[0]);
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                }

            }


        }


        /// <summary>
        /// Add new row to table "Points". 
        /// </summary>
        /// <param name="AddPoints"></param>
        public static void AddPoints(int userID, int score, DateTime date, string game)
        {
            string sql = "INSERT INTO Points (UserID, Score, HappenedOn, Game) VALUES (@UserID, @Score, @Date, @Game)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        MySqlParameter parameterUN = new MySqlParameter("@UserID", userID);
                        MySqlParameter parameterSC = new MySqlParameter("@Score", score);
                        MySqlParameter parameterDA = new MySqlParameter("@Date", date);
                        MySqlParameter parameterGA = new MySqlParameter("@Game", game);

                        cmd.Parameters.Add(parameterUN);
                        cmd.Parameters.Add(parameterSC);
                        cmd.Parameters.Add(parameterDA);
                        cmd.Parameters.Add(parameterGA);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                }

            }

        }

        /// <summary>
        /// Add new row to table "Expenditure". 
        /// </summary>
        /// <param name="AddExpenditures"></param>
        public static void AddExpenditures(int userID, int amount, string game)
        {
            string sql = "INSERT INTO Expenditures (UserID, amount, Game) VALUES (@UserID, @Amount, @Game)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        MySqlParameter parameterUN = new MySqlParameter("@UserID", userID);
                        MySqlParameter parameterSC = new MySqlParameter("@Amount", amount);
                        MySqlParameter parameterGA = new MySqlParameter("@Game", game);

                        cmd.Parameters.Add(parameterUN);
                        cmd.Parameters.Add(parameterSC);
                        cmd.Parameters.Add(parameterGA);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                }

            }

        }

        /// <summary>
        /// Get the amount of chips a player has deposited on their bankaccount. 
        /// </summary>
        /// <param name="GetDeposited"></param>
        public static int GetDeposited(int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT amountDeposited FROM BankAccount WHERE UserID = @userID", connection);

                MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);
                cmd.Parameters.Add(parameterUserID);

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        rdr.Read();
                        return Convert.ToInt32(rdr[0]);
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    

                }
            }

        }

        /// <summary>
        /// Get the amount of chips a player has on their hand. 
        /// </summary>
        /// <param name="GetOnHand"></param>
        public static int GetOnHand(int userID)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT amountOnHand FROM BankAccount WHERE UserID = @userID", connection);

                MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);
                cmd.Parameters.Add(parameterUserID);

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        rdr.Read();
                        return Convert.ToInt32(rdr[0]);
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    

                }
            }

        }


        /// <summary>
        /// Add a new row to table "Player".
        /// </summary>
        /// <param name="CreateNewPlayer"></param>
        public static void CreateNewPlayer(string username, string firstname, string lastname, string password)
        {
            string hashedPWD = GetHashString(password);
            

            string sql = "INSERT INTO player (Firstname, Lastname, LastSpin, Username, Password) VALUES (@Firstname, @Lastname, '2001-01-01 00:00:00', @Username, @Password)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        MySqlParameter parameterFN = new MySqlParameter("@Firstname", firstname);
                        MySqlParameter parameterLN = new MySqlParameter("@Lastname", lastname);
                        MySqlParameter parameterUN = new MySqlParameter("@Username", username);
                        MySqlParameter parameterPWD = new MySqlParameter("@Password", hashedPWD);

                        cmd.Parameters.Add(parameterFN);
                        cmd.Parameters.Add(parameterLN);
                        cmd.Parameters.Add(parameterUN);
                        cmd.Parameters.Add(parameterPWD);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                }

            }

        }

        /// <summary>
        /// Get the amount of chips, saved up in the bank.   
        /// </summary>
        /// <param name="GetChipsFromBank"></param>
        public static int GetChipsFromBank()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT amountDeposited FROM BankAccount WHERE UserID = 1", connection);

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        rdr.Read();
                        return Convert.ToInt32(rdr[0]);

                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                }
            }


        }

        /// <summary>
        /// Deposit a set amount of chips from a players hand to their bankaccount. 
        /// </summary>
        /// <param name="DepositChips"></param>
        public static void DepositChips(int userID, int amount)
        {
            string sql = "UPDATE BankAccount SET amountDeposited = amountDeposited + @amount, amountOnHand = amountOnHand - @amount WHERE userID = @userID";

            using (var connection = new MySqlConnection(connectionString))
            {
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        MySqlParameter parameterAmount = new MySqlParameter("@amount", amount);
                        MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);

                        cmd.Parameters.Add(parameterAmount);
                        cmd.Parameters.Add(parameterUserID);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                }
            }

        }

        /// <summary>
        /// Withdraw a set amount of chips from a users bankaccount to their hand. 
        /// </summary>
        /// <param name="WithdrawChips"></param>
        public static void WithdrawChips(int userID, int amount)
        {
            string sql = "UPDATE BankAccount SET amountDeposited = amountDeposited - @amount, amountOnHand = amountOnHand + @amount WHERE userID = @userID";

            using (var connection = new MySqlConnection(connectionString))
            {
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        MySqlParameter parameterAmount = new MySqlParameter("@amount", amount);
                        MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);

                        cmd.Parameters.Add(parameterAmount);
                        cmd.Parameters.Add(parameterUserID);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                }
            }

        }


        /// <summary>
        /// Remove the set amount of chips from players hand and add to the bank. 
        /// </summary>
        /// <param name="SetChips"></param>
        public static void SetChips(int userID, int amount)
        {
            string sql = "UPDATE BankAccount SET amountOnHand = amountOnHand - @amount WHERE userID = @userID";
            string sqlBank = "UPDATE BankAccount SET amountDeposited = amountDeposited + @amount WHERE userID = 1";


            using (var connection = new MySqlConnection(connectionString))
            {
                using (var cmd = new MySqlCommand(sql, connection))
                {
                    try
                    {
                        MySqlParameter parameterAmount = new MySqlParameter("@amount", amount);
                        MySqlParameter parameterUserID = new MySqlParameter("@userID", userID);

                        cmd.Parameters.Add(parameterAmount);
                        cmd.Parameters.Add(parameterUserID);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                    
                }
                using (var cmd = new MySqlCommand(sqlBank, connection))
                {
                    try
                    {
                        MySqlParameter parameterAmount = new MySqlParameter("@amount", amount);
                        cmd.Parameters.Add(parameterAmount);
                        cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                    
                }
            }

        }

        /// <summary>
        /// Get top ten scores from chosen game. 
        /// </summary>
        /// <param name="GetTop10"></param>
        public static ObservableCollection<Points> GetTop10(string game)
        {
            ObservableCollection<Points> points = new ObservableCollection<Points>();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT Score, HappenedOn, UserID FROM Points WHERE game = @game ORDER BY score DESC LIMIT 10", connection);

                MySqlParameter parameterUserID = new MySqlParameter("@game", game);
                cmd.Parameters.Add(parameterUserID);

                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    try
                    {
                        while (rdr.Read())
                        {

                            int score = Convert.ToInt32(rdr[0]);
                            DateTime date = Convert.ToDateTime(rdr[1]);
                            int uId = Convert.ToInt32(rdr[2]);

                            Points m = new Points(score, date, game, uId);
                            points.Add(m);


                        }

                    }
                    catch (MySqlException)
                    {

                        throw new DBException();
                    }
                }

            }

            return points;

        }


    }
}
