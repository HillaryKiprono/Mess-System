<!DOCTYPE html>
<html>

<head>

	<!-- Including the bootstrap CDN -->
	<link rel="stylesheet" href=
"https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/css/bootstrap.min.css">
	<script src=
"https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js">
	</script>
	<script src=
"https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js">
	</script>
	<script src=
"https://maxcdn.bootstrapcdn.com/bootstrap/4.4.1/js/bootstrap.min.js">
	</script>
</head>
<style>
        .navbar
        {
            border:5px solid #ede247;  
            
        }
      </style>
<body>

	<!-- Creating a navigation bar using the
		.navbar class of bootstrap -->
	<nav class="navbar navbar-expand-sm bg-dark">
    <img src="image/kibu.png" alt="" width="70" height="70">
		<ul class="navbar-nav ml-auto">
			<li class="nav-item">
            <a class="nav-link" href="login.php">Login</a>
			</li>
			<li class="nav-item">
				<a class="nav-link" href="signup.php">
				Register
				</a>
			</li>
	
			<li class="nav-item">
				<a class="nav-link" href="help.php">
				Help
				</a>
			</li>
		</ul>
	</nav>

	<div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img class="d-block w-100" src="image/res1.jpg" alt="first slide" width="600" height="400">
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="image/res2.jpg" alt="Second slide" width="600" height="400">
    </div>
    <div class="carousel-item">
      <img class="d-block w-100" src="image/res3.jpg" alt="third slide" width="600" height="400">
    </div>
  </div>
  <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
    <span class="sr-only">Previous</span>
  </a>
  <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
    <span class="carousel-control-next-icon" aria-hidden="true"></span>
    <span class="sr-only">Next</span>
  </a>
</div>
</body>
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
</html>
