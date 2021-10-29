<?php
include'config.php';
if(isset($_POST['submit']))
{
    $fname=$_POST['food_name'];
    $fprice=$_POST['food_price'];
    $fqty=$_POST['food_qty'];
    $fcode=$_POST['food_code'];
    $filename = 'image/'.$_FILES['image']['name'];
    // Select file type
//$imageFileType = strtolower(pathinfo($filename,PATHINFO_EXTENSION));
	
// valid file extensions
//$extensions_arr = array("jpg","jpeg","png","gif");

// Check extension
//if( in_array($imageFileType,$extensions_arr) ){

// Upload files and store in database

//if(move_uploaded_file($_FILES["image"]["name"],'upload/'.$filename)){
  // Image db insert sql
  // $insert = "INSERT into image(file_name,uploaded_on,status) values('$filename',now(),1)";
  //$sql="INSERT INTO fooditem(food_name,food_price,food_qty,food_code,image) 
  //VALUES('$fname','$fprice','$fqty','$fcode','$filename')";
  //if(mysqli_query($conn, $insert)){
   // echo 'Data inserted successfully';
 // }
  //else{
   // echo 'Error: '.mysqli_error($conn);
  //}
// }else{
//   echo 'Error in uploading file - '.$_FILES['image']['name'].'
// ';
// }   
  $insert = "INSERT into image(file_name,uploaded_on,status) values('$filename',now(),1)";
    $sql="INSERT INTO fooditem(food_name,food_price,food_qty,food_code,image) 
    VALUES('$fname','$fprice','$fqty','$fcode','$filename')";         
          if(mysqli_query($conn,$sql))
           {
                 echo '<script> alert("Menu Item Successful Uploaded");</script>';
                $_SESSION['message']="Successfully uploaded";
               
                header('refresh:0;url=adminlogin.php');
              }
               else{
                 echo '<script> alert("Fail to upload the food item");</script>';

              }
     
          }
    
        
         else
       {
           $_SESSION['message']="Please upload only!JPG,PNG or GIF image!";  
       }


?> 


