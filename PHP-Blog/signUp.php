<form method="post" action="php/registration.php" class="singup">
    <h1>Sign up</h1>

    <label for="name">Name*</label>
    <input name="name" type="text" id="name" class="user" placeholder="e.g. John Doe" required="required" pattern="[\w]{3,}" title="At least 3 letters or underscores!"/>

    <label for="username">Username* &emsp;
        <span id="user-length">/Username must have only one word/</span>
        <span id="userCharacter-length">/Username must have at least 3 characters/</span>
    </label>
    <input name="username" type="text" id="username" class="user" placeholder="e.g. greatname123" pattern="[^\s]{3,}" title="At least 3 characters, no whitespaces!"/>
    <img src="images/Tick.png" class="positive" id="positive-user" alt="correct"/>
    <img src="images/Red_x.png" class="negative" id="negative-user" alt="incorrect"/>

    <label for="email">Email*</label>
    <input name="email" type="email" id="email" class="email" placeholder="e.g. mymail@mail.com"/>
    <img src="images/Tick.png" class="positive" id="positive-email" alt="correct"/>
    <img src="images/Red_x.png" class="negative" id="negative-email" alt="incorrect"/>

    <label for="password">Password* &emsp;<span id="pass-length">/At least 4 characters/</span></label>
    <input name="password" type="password" id="password" class="password" placeholder="e.g. Ytr7d!0f" pattern=".{4,}" title="At least 4 characters!"/>

    <label for="confirm-pass">Confirm password*</label>
    <input name="confirm-pass" type="password" id="confirm-pass" class="password" placeholder="e.g. Ytr7d!0f" pattern=".{4,}" title="At least 4 characters!"/>
    <img src="images/Tick.png" class="positive" id="positive-pass" alt="correct"/>
    <img src="images/Red_x.png" class="negative" id="negative-pass" alt="incorrect"/>

    <label for="city">City</label>
    <input name="city" type="text" id="city" class="city" placeholder="e.g. Sofia"/>

    <label for="country">Country</label>
    <input name="country" type="text"  id="country" class="country" placeholder="e.g. Bulgaria"/>
    <input name="submit" type="submit" value="Submit" id="registerButton" class="buttons"/>
</form>