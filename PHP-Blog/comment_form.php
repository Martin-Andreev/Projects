<form method="get" action="php/savecomment.php" class="commentForm" id="comment-form-<?php echo $post[0]?>" style="display:none;">
    <h4>Write a comment:</h4>
    <input type="hidden" name="post-id" value="<?php echo $post[0] ?>">
    <div class="input-group">
        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span> </span>
        <input type="text" class="form-control" placeholder="Your Name" name="comment-name" required="required" pattern=".{3,}" title="At least 3 characters!">
    </div>
    <div class="input-group">
        <span class="input-group-addon">@</span>
        <input type="text" class="form-control" placeholder="Your E-mail" name="comment-email">
    </div>
    <textarea class="form-control" name="comment-content" rows="3" placeholder="Write your comment here...." required="required" title="At least 3 characters!"></textarea>
    <input class="btn btn-default submitBtn" type="submit" value="Submit" name="comment-submit">
</form>
