 
<HTML>
<head>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</head>
<body>
<form >
<div class="card-columns">
<?php
                  $mc=$_POST['suggest'];
                  include 'config.php';
                  $qry='select * from fooditem;
                  $run=mysqli_query($con,$qry);
                  while ($rows=mysqli_fetch_array($run))
                  {
                      
                        echo '<img class="card-img-top" src="image\\'.$rows['id'].'.jpg" height="100px" width="100px" alt="'.$rows['ItemName'].'">';
                       echo '<div class="card-body">';
                  echo '<p class="card-text">'.$rows['food_name'].'</p>';
                  echo '<p class="card-text">Rs.'.$rows['food_price'].'</p>';
                       
                         echo '</div></div>';
                  }
?>
</div>
</form>
</body>
</HTML>
