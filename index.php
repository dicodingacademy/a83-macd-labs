<html>
 <head>
 <Title>Registration Form</Title>
 <link href="style.css" rel="stylesheet" type="text/css">
 <script src="style.js" type="text/javascript"></script>
 </head>
 <body>

 <div class="user">
    <header class="user__header">
        <img src="https://s3-us-west-2.amazonaws.com/s.cdpn.io/3219/logo.svg" alt="" />
        <h1 class="user__title">REGISTER FORM</h1>
    </header>
    
    <form class="form" action="index.php" method="post" enctype="multipart/form-data">
        <div class="form__group">
            <input type="text" placeholder="Name" name="name" class="form__input" />
        </div>
        
        <div class="form__group">
            <input type="email" placeholder="Email" name="email" class="form__input" />
        </div>
        
        <div class="form__group">
            <input type="text" placeholder="Job" name="job" class="form__input" />
        </div>
        
        <button class="btn-blue" type="submit" name="submit">Register</button>
        <button class="btn-gray" type="submit" name="load_data" >Load Data</button>
    </form>
</div>


 <?php
    $host = "oimappserver.database.windows.net";
    $user = "oimtrust";
    $pass = "Rahasia123!";
    $db = "db_oimapp";

    try {
        $conn = new PDO("sqlsrv:server = $host; Database = $db", $user, $pass);
        $conn->setAttribute( PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION );
    } catch(Exception $e) {
        echo "Failed: " . $e;
    }

    if (isset($_POST['submit'])) {
        try {
            $name = $_POST['name'];
            $email = $_POST['email'];
            $job = $_POST['job'];
            $date = date("Y-m-d");
            // Insert data
            $sql_insert = "INSERT INTO users (name, email, job, date) 
                        VALUES (?,?,?,?)";
            $stmt = $conn->prepare($sql_insert);
            $stmt->bindValue(1, $name);
            $stmt->bindValue(2, $email);
            $stmt->bindValue(3, $job);
            $stmt->bindValue(4, $date);
            $stmt->execute();
        } catch(Exception $e) {
            echo "Failed: " . $e;
        }

        echo "<h3>Your're registered!</h3>";
    } else if (isset($_POST['load_data'])) {
        try {
            $sql_select = "SELECT * FROM users";
            $stmt = $conn->query($sql_select);
            $registrants = $stmt->fetchAll(); 
            if(count($registrants) > 0) {
                echo "<h2>People who are registered:</h2>";
                echo "<table>";
                echo "<tr><th>Name</th>";
                echo "<th>Email</th>";
                echo "<th>Job</th>";
                echo "<th>Date</th></tr>";
                foreach($registrants as $registrant) {
                    echo "<tr><td>".$registrant['name']."</td>";
                    echo "<td>".$registrant['email']."</td>";
                    echo "<td>".$registrant['job']."</td>";
                    echo "<td>".$registrant['date']."</td></tr>";
                }
                echo "</table>";
            } else {
                echo "<h3>No one is currently registered.</h3>";
            }
        } catch(Exception $e) {
            echo "Failed: " . $e;
        }
    }
 ?>
 </body>
 </html>