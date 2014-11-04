package com.game;

import java.awt.Graphics;
import java.awt.Rectangle;
import java.io.File;
import java.util.Random;

import com.game.input.Keyboard;

public class Ship extends Tile {

	private Random rand;

	public Ship(int x, int y, int size, File imageSrc) {
		super(x, y, size, imageSrc);
		rand = new Random();
	}

	public Rectangle getRect() {
		return new Rectangle(getX() + getSize() / 8, getY() + getSize() / 8,
				getSize() - getSize() / 4, getSize() - getSize() / 4);
	}

	public void update(Keyboard keyboard) {
		if (keyboard.top && getY() > 0)
			setY(getY() - 2);
		if (keyboard.down && getY() < Game.HEIGHT - getSize())
			setY(getY() + 2);
		if (keyboard.left && getX() > 0)
			setX(getX() - 2);
		if (keyboard.right && getX() < Game.WIDTH - getSize())
			setX(getX() + 2);
		if (keyboard.space)
			fire();
	}

	private void fire() {
		if (rand.nextInt(10) > 7) {
			Game.bullets.add(new Bullet(getX() + 14, getY(), 32, new File(
					"res\\bullet.png"), 0, -1, 5));
			Game.playSound("res\\shoot.wav");
		}
	}

	public void render(Graphics g) {
		g.drawImage(getImage(), getX(), getY(), getSize(), getSize(), null,
				null);
	}

}
