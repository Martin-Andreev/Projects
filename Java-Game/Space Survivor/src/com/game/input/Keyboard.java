package com.game.input;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class Keyboard implements KeyListener {
	private boolean[] keys = new boolean[120];

	public boolean left, right, top, down, space, restart, exit, pause, start;

	public void update() {
		left = keys[KeyEvent.VK_LEFT];
		right = keys[KeyEvent.VK_RIGHT];
		top = keys[KeyEvent.VK_UP];
		down = keys[KeyEvent.VK_DOWN];
		space = keys[KeyEvent.VK_SPACE];
		restart = keys[KeyEvent.VK_Y];
		exit = keys[KeyEvent.VK_E];
		pause = keys[KeyEvent.VK_ESCAPE];
		start = keys[KeyEvent.VK_ENTER];
	}

	public void keyPressed(KeyEvent e) {
		keys[e.getKeyCode()] = true;
	}

	public void keyReleased(KeyEvent e) {
		keys[e.getKeyCode()] = false;
	}

	public void keyTyped(KeyEvent e) {

	}
}
