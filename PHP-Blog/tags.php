<div class="post-lists tags">
    <h2>Popular tags</h2>

    <?php
    $sql = "SELECT * FROM tags GROUP BY tags";
    $res = mysqli_query($con, $sql);
    while($tag = mysqli_fetch_assoc($res)) {
        $sqlCount = "SELECT * FROM tags WHERE tags ='$tag[tags]'";
        $resCount = mysqli_query($con, $sqlCount);
        $count = mysqli_num_rows($resCount);
        echo "<a href=\"viewbytags.php?tag=$tag[tags]\" style=\"font-size: ".tagSize($count)."\">  $tag[tags]($count),  </a>";
    }


    function tagSize($count) {
        if($count > 5) {
            return "18px";
        }
        elseif ($count > 10) {
            return "24px";
        }
        elseif ($count > 15) {
            return "28px";
        }
        elseif ($count > 20) {
            return "32px";
        }
        else {
            return "13px";
        }
    }
    ?>
</div>