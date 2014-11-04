package com.game;

import java.awt.Graphics;
import java.awt.Rectangle;
import java.io.File;

public class Bullet extends Tile {

	private int velocityX;
	private int velocityY;
	private int speed;


	public Bullet(int x, int y, int size, File imageSrc, int velocityX,
			int velocityY, int speed) {
		super(x, y, size, imageSrc);

		this.velocityX = velocityX;
		this.velocityY = velocityY;
		this.speed = speed;
	}
	
	public Rectangle getRect(){
		return new Rectangle(getX(), getY(), getSize(), getSize());
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

	public void update(int index) {
		setX(getX() + this.velocityX * speed);
		setY(getY() + this.velocityY * speed);

	}

	public void render(Graphics g) {
		g.drawImage(getImage(), getX(), getY(), getSize(), getSize(), null,
				null);
	}

}