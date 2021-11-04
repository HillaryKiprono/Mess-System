 
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
<table class="table">
  <thead>
    <tr>
<th>ID</th>
<th>Name</th>
<!-- <th>email</th> -->
<th>phone</th>
<th>products</th>
<th>amount_paid</th>
<!-- <th>food Name</th> -->
 <th colspan=2 align="center">ACTION</th>
</tr></thead><tbody>
<?php
include 'config.php';
$qry="select * from orders";
$recset=mysqli_query($conn,$qry);
while ($row=mysqli_fetch_array($recset))
{
      echo "<td>";
      echo $row["id"];
      echo "</td>";
      echo "<td>";
      echo $row["name"];
       
    //   echo "</td>";
    //   echo "<td>";
    //   echo $row["email"];

      echo "</td>";
      echo "<td>";
      echo $row["phone"];

      echo "</td>";
      echo "<td>";
      echo $row["products"];

      echo "</td>";
      echo "<td>";
      echo $row["amount_paid"];
      echo "</td>";
      $id=$row["id"];
      echo "<td>";
      echo "<a href='delete.php?key=?'>DELETE</>";
      echo "</td>";
      echo "<TD><a href='modify.php?key=?>MODIFY</>";
      echo "</td></tr>";
}         
?>
</tbody>
</table>
