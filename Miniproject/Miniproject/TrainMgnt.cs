using System;
using System.Data;
using System.Data.SqlClient;

namespace TrainMgnt
{
    internal class Program
    {
        static string connStr =
        @"Data Source=ZT-89BDJ84\SQLEXPRESS;Initial Catalog=TrainMgntDB;Integrated Security=True";

        static int loggedUserId = 0;

        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            Console.WriteLine("\n----- Train Reservation System -----");

            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. User Login");
            Console.WriteLine("3. New User");
            Console.WriteLine("4. Exit");

            Console.Write("Choice : ");
            int ch = Convert.ToInt32(Console.ReadLine());

            switch (ch)
            {
                case 1: AdminLogin(); break;
                case 2: UserLogin(); break;
                case 3: Register(); break;
                case 4: Environment.Exit(0); break;
                default:
                    Console.WriteLine("Invalid Choice");
                    Start();
                    break;
            }
        }

        // admin login
        static void AdminLogin()
        {
            Console.Write("Username : ");
            string u = Console.ReadLine();

            Console.Write("Password : ");
            string p = Console.ReadLine();

            if (u == "admin" && p == "123")
            {
                Console.WriteLine("Admin Login Success");
                AdminMenu();
            }
            else
            {
                Console.WriteLine("Invalid Admin Login");
                Start();
            }
        }

        // new user
        static void Register()
        {
            Console.Write("Username : ");
            string u = Console.ReadLine();

            Console.Write("Password : ");
            string p = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand check = new SqlCommand(
                    "select count(*) from Users where Username=@u", con);

                check.Parameters.AddWithValue("@u", u);

                int count = (int)check.ExecuteScalar();

                if (count > 0)
                {
                    Console.WriteLine("Username Already Exists");
                    return;
                }

                SqlCommand cmd = new SqlCommand(
                    "insert into Users values(@u,@p)", con);

                cmd.Parameters.AddWithValue("@u", u);
                cmd.Parameters.AddWithValue("@p", p);

                cmd.ExecuteNonQuery();

                Console.WriteLine("Registration Successfull");
            }

            Start();
        }

        // user login
        static void UserLogin()
        {
            Console.Write("Username : ");
            string u = Console.ReadLine();

            Console.Write("Password : ");
            string p = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "select UserId from Users where Username=@u and Password=@p", con);

                cmd.Parameters.AddWithValue("@u", u);
                cmd.Parameters.AddWithValue("@p", p);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    loggedUserId = Convert.ToInt32(result);
                    Console.WriteLine("Login Successfull");
                    UserMenu();
                }
                else
                {
                    Console.WriteLine("Invalid Login");
                    Start();
                }
            }
        }

        // admin menu
        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n----- Admin Menu -----");

                Console.WriteLine("1. View Trains");
                Console.WriteLine("2. Add Train");
                Console.WriteLine("3. Delete Train");
                Console.WriteLine("4. Logout");

                Console.Write("Choice : ");

                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        ViewTrains();
                        break;

                    case 2:
                        AddTrain();
                        break;

                    case 3:
                        Console.Write("Enter Train No : ");
                        int trainNo = Convert.ToInt32(Console.ReadLine());
                        DeleteTrain(trainNo);
                        break;

                    case 4:
                        Start();
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }

        // user menu
      static void UserMenu()
{
    while (true)
    {
        Console.WriteLine("\n----- User Menu -----");

        Console.WriteLine("1. Search Trains");
        Console.WriteLine("2. Book Ticket");
        Console.WriteLine("3. View Tickets");
        Console.WriteLine("4. Cancel Ticket");
        Console.WriteLine("5. Logout");

        Console.Write("Choice : ");

        int ch = Convert.ToInt32(Console.ReadLine());

        switch (ch)
        {
            case 1:
               ViewTrains();
                break;

            case 2:
                BookTicket();
                break;

            case 3:
                ViewMyTickets();
                break;

            case 4:
                CancelTicket();
                break;

            case 5:
                Start();
                return;

            default:
                Console.WriteLine("Invalid Choice");
                break;
        }
    }
}
        // search
        static void ViewTrains()
        {
            Console.Write("From Station : ");
            string from = Console.ReadLine();

            Console.Write("To Station : ");
            string to = Console.ReadLine();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                @"select t.TrainNo,
                 t.TrainName,
                 tc.ClassName,
                 tc.AvailableSeats,
                 tc.Charges,
                 tc.Status
          from Train t
          join TrainClass tc
          on t.TrainNo = tc.TrainNo
          where t.FromStation=@f
          and t.ToStation=@t
          and t.IsDeleted=0
          order by t.TrainNo", con);

                cmd.Parameters.AddWithValue("@f", from);
                cmd.Parameters.AddWithValue("@t", to);

                SqlDataReader dr = cmd.ExecuteReader();

                int currentTrain = -1;

                Console.WriteLine();

                while (dr.Read())
                {
                    int trainNo = Convert.ToInt32(dr["TrainNo"]);

                    if (trainNo != currentTrain)
                    {
                        Console.WriteLine("\nTrain : " + dr["TrainNo"]);
                        Console.WriteLine("Name  : " + dr["TrainName"]);
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("Class     | Seats | Charges | Status");
                        Console.WriteLine("--------------------------------------------------");

                        currentTrain = trainNo;
                    }

                    Console.WriteLine("{0,-9} | {1,-5} | {2,-7} | {3,-7}", dr["ClassName"], dr["AvailableSeats"], dr["Charges"], dr["Status"]);
                }

                dr.Close();
            }
        }

        //add train
        static void AddTrain()
        {
            Console.Write("Train No : ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Train Name : ");
            string trainName = Console.ReadLine();

            Console.Write("From Station : ");
            string from = Console.ReadLine();

            Console.Write("To Station : ");
            string to = Console.ReadLine();

            Console.WriteLine("\n----- Sleeper -----");

            Console.Write("Seats : ");
            int sleeperSeats =
                Convert.ToInt32(Console.ReadLine());

            Console.Write("Fare : ");
            decimal sleeperFare =
                Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("\n----- 3AC -----");

            Console.Write("Seats : ");
            int ac3Seats =
                Convert.ToInt32(Console.ReadLine());

            Console.Write("Fare : ");
            decimal ac3Fare =
                Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("\n----- 2AC -----");

            Console.Write("Seats : ");
            int ac2Seats =
                Convert.ToInt32(Console.ReadLine());

            Console.Write("Fare : ");
            decimal ac2Fare =
                Convert.ToDecimal(Console.ReadLine());

            using (SqlConnection con =
                new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand check =
                    new SqlCommand(
                    "select count(*) from Train where TrainNo=@n",
                    con);

                check.Parameters.AddWithValue("@n",
                    trainNo);

                int count =
                    (int)check.ExecuteScalar();

                if (count > 0)
                {
                    Console.WriteLine(
                        "Train Number Already Exists");
                    return;
                }

                SqlCommand trainCmd =
                    new SqlCommand(
                    @"insert into Train values (@n,@name,@f,@t,0)", con);

                trainCmd.Parameters.AddWithValue(
                    "@n", trainNo);

                trainCmd.Parameters.AddWithValue(
                    "@name", trainName);

                trainCmd.Parameters.AddWithValue(
                    "@f", from);

                trainCmd.Parameters.AddWithValue(
                    "@t", to);

                trainCmd.ExecuteNonQuery();

                AddClass(con, trainNo, "Sleeper", sleeperSeats, sleeperFare);

                AddClass(con, trainNo, "3AC", ac3Seats, ac3Fare);

                AddClass(con, trainNo, "2AC", ac2Seats, ac2Fare);

                Console.WriteLine("\nTrain Added Successfully");
            }
        }
        static void AddClass(SqlConnection con,
                      int trainNo,
                      string className,
                      int seats,
                      decimal fare)
        {
            SqlCommand cmd = new SqlCommand(
            @"INSERT INTO TrainClass
      (
          TrainNo,
          ClassName,
          TotalSeats,
          AvailableSeats,
          Charges,
          Status
      )
      VALUES
      (
          @n,
          @c,
          @ts,
          @as,
          @ch,
          'active'
      )", con);

            cmd.Parameters.AddWithValue("@n", trainNo);
            cmd.Parameters.AddWithValue("@c", className);
            cmd.Parameters.AddWithValue("@ts", seats);
            cmd.Parameters.AddWithValue("@as", seats);
            cmd.Parameters.AddWithValue("@ch", fare);

            cmd.ExecuteNonQuery();
        }
        // delete 
        static void DeleteTrain(int trainNo)
        {
            using (SqlConnection con =
                new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand check =
                    new SqlCommand( @"select count(*) from Booking where TrainNo=@n",
                    con);

                check.Parameters.AddWithValue(
                    "@n",
                    trainNo);

                int count =
                    (int)check.ExecuteScalar();

                if (count > 0)
                {
                    Console.WriteLine(
                    "Cannot Delete Train.");
                    Console.WriteLine(
                    "Active Bookings Exist.");
                    return;
                }

                SqlCommand cmd =
                    new SqlCommand( @"update Train set IsDeleted=1 where TrainNo=@n",
                    con);

                cmd.Parameters.AddWithValue(
                    "@n",
                    trainNo);

                int rows =
                    cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    Console.WriteLine(
                    "Train Deleted Successfully");
                }
                else
                {
                    Console.WriteLine(
                    "Train Not Found");
                }
            }
        }
        // booking
        static void BookTicket()
        {
            Console.WriteLine("\n----- Book Ticket -----");

            Console.Write("Train No : ");
            int trainNo = Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand trainCmd = new SqlCommand(
                @"select TrainName, FromStation, ToStation 
          from Train 
          where TrainNo=@n and IsDeleted=0", con);

                trainCmd.Parameters.AddWithValue("@n", trainNo);

                SqlDataReader tr = trainCmd.ExecuteReader();

                if (!tr.Read())
                {
                    Console.WriteLine("Invalid Train Number");
                    tr.Close();
                    return;
                }

                string trainName = tr["TrainName"].ToString();
                string from = tr["FromStation"].ToString();
                string to = tr["ToStation"].ToString();

                tr.Close();

                SqlCommand classCmd = new SqlCommand(
                @"select t.TrainNo, t.TrainName, tc.ClassName,
                 tc.AvailableSeats, tc.Charges, tc.Status
          from Train t
          join TrainClass tc ON t.TrainNo = tc.TrainNo
          where t.TrainNo=@n", con);

                classCmd.Parameters.AddWithValue("@n", trainNo);

                SqlDataReader dr = classCmd.ExecuteReader();

                while (dr.Read())
                {
                    Console.WriteLine($"{dr["ClassName"]} | Seats: {dr["AvailableSeats"]} | Fare: {dr["Charges"]} | Status: {dr["Status"]}");
                }

                dr.Close();

                Console.Write("\nEnter Class : ");
                string cls = Console.ReadLine();

                SqlCommand seatCmd = new SqlCommand(
                @"select AvailableSeats, Charges, Status 
          from TrainClass 
          where TrainNo=@n and ClassName=@c", con);

                seatCmd.Parameters.AddWithValue("@n", trainNo);
                seatCmd.Parameters.AddWithValue("@c", cls);

                SqlDataReader seatReader = seatCmd.ExecuteReader();

                if (!seatReader.Read())
                {
                    Console.WriteLine("Invalid Class");
                    seatReader.Close();
                    return;
                }

                int availableSeats = Convert.ToInt32(seatReader["AvailableSeats"]);
                decimal fare = Convert.ToDecimal(seatReader["Charges"]);
                string status = seatReader["Status"].ToString();

                seatReader.Close();

                if (status.ToLower() != "active")
                {
                    Console.WriteLine("Selected Class Is Inactive");
                    return;
                }

                Console.Write("Passenger Count : ");
                int passengerCount = Convert.ToInt32(Console.ReadLine());

                if (passengerCount <= 0 || passengerCount > 3)
                {
                    Console.WriteLine("Maximum 3 Passengers Allowed");
                    return;
                }

                if (availableSeats < passengerCount)
                {
                    Console.WriteLine("Only " + availableSeats + " Seats Available");
                    return;
                }

                string[] names = new string[passengerCount];
                int[] ages = new int[passengerCount];
                string[] genders = new string[passengerCount];

                for (int i = 0; i < passengerCount; i++)
                {
                    Console.WriteLine("\nPassenger " + (i + 1));

                    Console.Write("Name : ");
                    names[i] = Console.ReadLine();

                    Console.Write("Age : ");
                    ages[i] = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Gender (M/F) : ");
                    genders[i] = Console.ReadLine().ToUpper();
                }

                decimal totalAmount = fare * passengerCount;

                Console.WriteLine("\nFare Per Ticket : " + fare);
                Console.WriteLine("Total Amount    : " + totalAmount);

                Console.WriteLine("\n----- Payment -----");
                Console.WriteLine("1. UPI");
                Console.WriteLine("2. Debit Card");
                Console.WriteLine("3. Credit Card");
                Console.WriteLine("4. Net Banking");

                Console.Write("Choose Payment Method : ");
                int payChoice = Convert.ToInt32(Console.ReadLine());

                string paymentMethod = "";

                switch (payChoice)
                {
                    case 1: paymentMethod = "UPI"; break;
                    case 2: paymentMethod = "Debit Card"; break;
                    case 3: paymentMethod = "Credit Card"; break;
                    case 4: paymentMethod = "Net Banking"; break;
                    default:
                        Console.WriteLine("Invalid Payment Method");
                        return;
                }

                Console.Write("Confirm Payment (Y/N) : ");
                string confirm = Console.ReadLine().ToUpper();

                if (confirm != "Y")
                {
                    Console.WriteLine("Payment Failed");
                    return;
                }

                SqlTransaction tx = con.BeginTransaction();

                try
                {
                     SqlCommand bookingCmd = new SqlCommand( @"insert into Booking (UserId, BookingDate, TravelDate, TrainNo, ClassName, PassengerCount, Amount, PaymentMethod)output inserted.BookingId values (@u, getdate(), getdate(), @n,
                      @c, @pc, @amt, @pm)",
                    con, tx);

                    bookingCmd.Parameters.AddWithValue("@u", loggedUserId);
                    bookingCmd.Parameters.AddWithValue("@n", trainNo);
                    bookingCmd.Parameters.AddWithValue("@c", cls);
                    bookingCmd.Parameters.AddWithValue("@pc", passengerCount);
                    bookingCmd.Parameters.AddWithValue("@amt", totalAmount);
                    bookingCmd.Parameters.AddWithValue("@pm", paymentMethod); 

                    int bookingId = (int)bookingCmd.ExecuteScalar();

                    for (int i = 0; i < passengerCount; i++)
                    {
                        SqlCommand passCmd = new SqlCommand(
                        @"insert into Passenger (BookingId, PassengerName, Age, Gender) values (@b, @p, @a, @g)", con, tx);

                        passCmd.Parameters.AddWithValue("@b", bookingId);
                        passCmd.Parameters.AddWithValue("@p", names[i]);
                        passCmd.Parameters.AddWithValue("@a", ages[i]);
                        passCmd.Parameters.AddWithValue("@g", genders[i]);
                        passCmd.ExecuteNonQuery();
                    }

                    SqlCommand updateSeat = new SqlCommand(
                    @"update TrainClass set AvailableSeats = AvailableSeats - @pc where TrainNo=@n and ClassName=@c", con, tx);

                    updateSeat.Parameters.AddWithValue("@pc", passengerCount);
                    updateSeat.Parameters.AddWithValue("@n", trainNo);
                    updateSeat.Parameters.AddWithValue("@c", cls);

                    updateSeat.ExecuteNonQuery();

                    tx.Commit();

                    Console.WriteLine("\nBooking Confirmed");
                    Console.WriteLine("Booking ID : " + bookingId);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    Console.WriteLine("Booking Failed : " + ex.Message);
                }
            }
        }

        // view tickets
        static void ViewMyTickets()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                @"select b.BookingId,
                 b.TrainNo,
                 t.TrainName,
                 t.FromStation,
                 t.ToStation,
                 b.ClassName,
                 b.PassengerCount,
                 b.Amount,
                 b.BookingDate
          from Booking b
          join Train t
          on b.TrainNo = t.TrainNo
          where b.UserId = @u
          order by b.BookingId", con);

                cmd.Parameters.AddWithValue("@u", loggedUserId);

                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);

                dr.Close();

                if (dt.Rows.Count == 0)
                {
                    Console.WriteLine("No Bookings Found");
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    int bookingId = Convert.ToInt32(row["BookingId"]);

                    Console.WriteLine("Booking ID : " + bookingId);
                    Console.WriteLine("Train No   : " + row["TrainNo"]);
                    Console.WriteLine("Train Name : " + row["TrainName"]);
                    Console.WriteLine("Route      : " + row["FromStation"] + " -- " + row["ToStation"]);
                    Console.WriteLine("Class      : " + row["ClassName"]);
                    Console.WriteLine("Passengers : " + row["PassengerCount"]);
                    Console.WriteLine("Amount     : " + row["Amount"]);
                    Console.WriteLine("Booked On  : " +
                        Convert.ToDateTime(row["BookingDate"]) .ToString("dd-MM-yyyy"));

                    Console.WriteLine("\nPassenger Details");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine("ID\tName\t\tAge\tGender");
                    Console.WriteLine("--------------------------------------");

                    SqlCommand passCmd = new SqlCommand(
                    @"select PassengerId, PassengerName, Age, Gender from Passenger where BookingId=@b", con);

                    passCmd.Parameters.AddWithValue("@b", bookingId);

                    SqlDataReader pdr = passCmd.ExecuteReader();

                    while (pdr.Read())
                    {
                        Console.WriteLine(
                            pdr["PassengerId"] + "\t" + pdr["PassengerName"] + "\t\t" + pdr["Age"] + "\t" + pdr["Gender"]);
                    }

                    pdr.Close();
                }
            }
        }

        // cance;

        static void CancelTicket()
        {
            Console.Write("Enter Booking ID : ");

            int bookingId =
                Convert.ToInt32(Console.ReadLine());

            using (SqlConnection con =
                new SqlConnection(connStr))
            {
                con.Open();

                SqlCommand cmd =
                    new SqlCommand(
                    @"select TrainNo,
                     ClassName,
                     Amount,
                     PassengerCount from Booking where BookingId=@b and UserId=@u", con);

                cmd.Parameters.AddWithValue( "@b", bookingId);

                cmd.Parameters.AddWithValue( "@u", loggedUserId);

                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.Read())
                {
                    Console.WriteLine("Invalid Booking ID");
                    return;
                }

                int trainNo =
                    Convert.ToInt32(dr["TrainNo"]);

                string cls =dr["ClassName"].ToString();

                decimal totalAmount =
                    Convert.ToDecimal( dr["Amount"]);

                int passengerCount =
                    Convert.ToInt32(
                    dr["PassengerCount"]);

                dr.Close();

                SqlCommand passCmd = new SqlCommand( @"select PassengerId,  PassengerName,  Age,  Gender from Passenger where BookingId=@b", con);

                passCmd.Parameters.AddWithValue( "@b", bookingId);

                SqlDataReader pdr = passCmd.ExecuteReader();

                Console.WriteLine( "\nPassengers");

                while (pdr.Read())
                {
                    Console.WriteLine( pdr["PassengerId"] + " | "
                    + pdr["PassengerName"] + " | " + pdr["Age"] + " | " + pdr["Gender"]);
                }

                pdr.Close();

                Console.Write( "\nPassenger ID To Cancel : ");

                int passengerId = Convert.ToInt32( Console.ReadLine());

                decimal refund = totalAmount / passengerCount;

                SqlCommand cancelCmd =
                    new SqlCommand( @"insert into Cancellation( BookingId, NoOfTickets, RefundAmount ) values ( @b, 1,  @r)", con);

                cancelCmd.Parameters.AddWithValue("@b",bookingId);

                cancelCmd.Parameters.AddWithValue("@r",refund);

                cancelCmd.ExecuteNonQuery();

                SqlCommand deletePassenger =
                    new SqlCommand(@"delete from Passenger where PassengerId=@p", con);

                deletePassenger.Parameters.AddWithValue( "@p", passengerId);

                deletePassenger.ExecuteNonQuery();

                SqlCommand seatUpdate =new SqlCommand( @"update TrainClass set AvailableSeats= AvailableSeats+1 where TrainNo=@n and ClassName=@c",  con);

                seatUpdate.Parameters.AddWithValue("@n", trainNo);

                seatUpdate.Parameters.AddWithValue("@c",cls);

                seatUpdate.ExecuteNonQuery();

                int remaining =passengerCount - 1;

                decimal remainingAmount =totalAmount - refund;

                if (remaining > 0)
                {
                    SqlCommand updateBooking =
                        new SqlCommand(@"update Booking  set PassengerCount=@pc, Amount=@amt where BookingId=@b", con);

                    updateBooking.Parameters.AddWithValue("@pc",remaining);

                    updateBooking.Parameters.AddWithValue("@amt",remainingAmount);

                    updateBooking.Parameters.AddWithValue("@b", bookingId);

                    updateBooking.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand deleteBooking =
                        new SqlCommand(@"delete from Booking where BookingId=@b", con);

                    deleteBooking.Parameters.AddWithValue("@b", bookingId);

                    deleteBooking.ExecuteNonQuery();
                }

                Console.WriteLine("\nPassenger Cancelled");

                Console.WriteLine("Refund Amount : "+ refund);

                Console.WriteLine("Seat Restored Successfully");
            }
        }
    }
}