package com.game;

import java.awt.Graphics;
import java.awt.Rectangle;
import java.io.File;
import java.io.IOException;
import java.util.Random;

import javax.imageio.ImageIO;

public class Asteroid extends Tile {

	private int velocityX;
	private int velocityY;
	private int speed;
	private static Random rand = new Random();

	public static String[] asteroidsType = { "res\\asteroid1.png",
			"res\\asteroid2.png", "res\\asteroid3.png", "res\\asteroid4.png",
			"res\\asteroid5.png" };

	public Asteroid(int x, int y, int size, File imageSrc, int velocityX,
			int velocityY, int speed) {
		super(x, y, size, imageSrc);

		this.velocityX = velocityX;
		this.velocityY = velocityY;
		this.speed = speed;
	}

	public Rectangle getRect() {
		return new Rectangle(getX() + getSize() / 8, getY() + getSize() / 8,
				getSize() - getSize() / 4, getSize() - getSize() / 4);
	}

	public int getVelocityX() {
		return velocityX;
	}

	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	public int getVelocityY() {
		return velocityY;
	}

	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}

	public static void spawn() {
		if (Game.overalScore % 200 == 0 && Game.overalScore != 0
				&& Game.levelScore != 0) {
			Game.spawnRate -= 2;
			if (Game.levels % 2 == 1) {
				Game.speedRate++;
			}
			Game.levels++;
			Game.levelScore = 0;
		}

		if (rand.nextInt(100) > Game.spawnRate) {
			Game.asteroids.add(new Asteroid(rand.nextInt((850 - 0) + 0), -135,
					rand.nextInt(60) + 25, new File(asteroidsType[rand
							.nextInt(5)]), 0, 1, Game.speedRate));
		}
	}

	public void update(int index) {
		setX(getX() + this.velocityX * speed);
		setY(getY() + this.velocityY * speed);

		if (Game.ship.getRect().intersects(getRect())) {
			Game.playSound("res\\explosion.wav");
			try {
				Game.ship.setImage(ImageIO.read(new File("res\\explosion.png")));
			} catch (IOException e) {
				e.printStackTrace();
			}
			Game.g.drawImage(Game.ship.getImage(),
					Game.ship.getX(), Game.ship.getY(), null);
			Game.isWaitingAfterDeath = true;
		}

		for (int i = 0; i < Game.bullets.size(); i++) {
			Bullet b = Game.bullets.get(i);

			if (b.getRect().intersects(getRect())) {
				Game.overalScore += 10;
				Game.levelScore += 10;
				Game.asteroids.remove(index);
				Game.bullets.remove(i);
				break;
			}
		}
	}

	public void render(Graphics g) {
		g.drawImage(getImage(), getX(), getY(), getSize(), getSize(), null,
				null);
	}
}
