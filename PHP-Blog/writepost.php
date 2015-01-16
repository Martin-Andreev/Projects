<?php
require 'header.php';
?>
<?php
if(isset($_SESSION['loggedUser'])) :
?>
<main>
    <div id="main-content">
        <?php
        include 'write.php';
        ?>
    </div>
    <?php else: ?>
    <main>
        <div id="main-content">
            <h3>Sorry, but you must be logged in to write a post!</h3>
        </div>
        <?php endif; ?>
        <aside id="right-write-post">
            <?php
            include 'lastposts.php';
            include 'months.php';
            include 'tags.php';
            ?>
        </aside>
    </main>
    <?php
    include 'footer.php';
    ?>

