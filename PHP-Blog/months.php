<div class="post-lists">
    <h2>Months</h2>
    <ul class="nav nav-tabs">
        <?php
        require 'config.php';
        date_default_timezone_set ("UTC");
        $year = date("Y");
        $month = date("n");

        for ($i = 0; $i < 12; $i++) {
            if ($month < 0) {
                $month = 12;
                $year--;
            }

            $monthQuery = "SELECT id FROM posts WHERE MONTH(date) = $month AND YEAR(date) = $year";
            $arr = $con->query($monthQuery);
            $postCount = $arr->num_rows;

            if ($postCount > 0):
                $monthName = date('F', mktime(0, 0, 0, $month, 10)); ?>

        <li><a href="view.php?<?php echo "query=month&month=$month&year=$year" ?>"><?php echo "$monthName $year ($postCount)" ?></a></li>

        <?php endif;
            $month-- ;
        }?>
    </ul>
</div>