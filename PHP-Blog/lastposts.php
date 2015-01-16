<div class="post-lists">
    <form action="viewSearch.php" method="GET">
        <input type="search" name="search" id="search-input" placeholder="Search..."/>
        <input type="submit" class="search-button" value=""/>
    </form>
    <h2>Last posts</h2>
    <ul class="nav nav-tabs">
        <?php
        require 'config.php';
        $lastPostsQuery = "SELECT * FROM posts ORDER BY date DESC LIMIT 0, 5";

        $arr = $con->query($lastPostsQuery);

        while($row = mysqli_fetch_assoc($arr)){
            $title = $row['title'];
            $date = $row['date'];
            $id = $row['id'];
            $cat = $row['category'];
            $category = $con->query("SELECT name FROM categories WHERE id = $cat")->fetch_all()[0][0];

            ?>
            <li><a href="view.php?query=post&id=<?php echo $id ?>">
                    <span class="title"><?php echo htmlentities($title)?></span><br>
                    <span class="date"><?php echo $date?></span> <br>
                    <span class="category">in <?php echo $category?></span>
                </a>
            </li>
        <?php } ?>
    </ul>
</div>