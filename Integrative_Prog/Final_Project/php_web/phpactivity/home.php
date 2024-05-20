<?php
   include("config/initialize.php");
   
   HTML :: head();
   $current_tab = " ";

   if(isset($_GET['tab']))
   {
    $current_tab = $_GET['tab'];
   }
   HTML :: sidebar($current_tab);
   HTML :: navbar();

   if($current_tab == "students")
   {
      student();
   }

   if($current_tab == "dashboard")
   {
    dashboard();
   }

   HTML ::footer();

?>
