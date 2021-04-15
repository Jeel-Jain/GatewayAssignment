package com.example.demo;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;

import org.springframework.hateoas.RepresentationModel;




@Entity
@Table(name="users")

public class User extends RepresentationModel<User> {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
private Long id;
	@Column(nullable = false,length=45)
	private String fname;
	private String lname;
	private String email;
	private String contact;
	private String password;
	private String role;
	private int isapprove;



public int getIsapprove() {
		return isapprove;
	}
	public void setIsapprove(int isapprove) {
		this.isapprove = isapprove;
	}
public String getFname() {
		return fname;
	}
	public void setFname(String fname) {
		this.fname = fname;
	}
	public String getLname() {
		return lname;
	}
	public void setLname(String lname) {
		this.lname = lname;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getContact() {
		return contact;
	}
	public void setContact(String contact) {
		this.contact = contact;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	public String getRole() {
		return role;
	}
	public void setRole(String role) {
		this.role = role;
	}
public Long getId() {
		return id;
	}
	public void setId(Long id) {
		this.id = id;
	}
	

}
