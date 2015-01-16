<form method="get" action="php/savepost.php" class="singup">
    <h1>Write post</h1>
    <input name="title" type="text" id="name" class="user-write" placeholder="Your title" required="required" pattern=".{3,}" title="At least 3 characters!"/>
    <label> Select Category: </label>
    <select class="form-control dropdown-category" name="category">
        <?php
        $sql = "SELECT * FROM categories";
        $result = mysqli_query($con, $sql);
        while($categories = mysqli_fetch_assoc($result)){
            echo "<option value='$categories[id]'>$categories[name]</option>";
        }
        ?>
    </select>
    <textarea name="editor1" id="editor1" rows="10" cols="80" required="required" pattern=".{3,}" title="At least 3 characters!">
        Enter text...
    </textarea>
    <script>
        CKEDITOR.replace( 'editor1' );
    </script>
    <input name="tags" type="text" id="name" class="user-write" placeholder="Add tags..."/>
    <input name="submit" type="submit" value="Submit" class="button-post"/>
</form>
