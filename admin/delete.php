 
<?php
include 'config.php';
$id=$_GET["key"];
$qry="delete from fooditem where food_code= '$fcode'";
if (mysqli_query($conn,$qry)==true)
{
      echo "<script> alert('Record Deleted');</script>";
      echo "<script> window.location='adminLogin.php';</script>";
}
?>
