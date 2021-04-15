package com.example.demo;

import java.util.List;
import java.util.Optional;

import org.hibernate.usertype.UserCollectionType;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.hateoas.EntityModel;
import org.springframework.hateoas.Link;
import org.springframework.hateoas.server.mvc.WebMvcLinkBuilder;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.linkTo;
import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.methodOn;
@RestController
public class UsersController {

	@Autowired UserRepository userRepo;
	@GetMapping("/students/{id}")
	  public User retrieveStudent(@PathVariable long id) throws Exception {
	    User student = userRepo.findByUserId(id);
	    
	    Link link=WebMvcLinkBuilder.linkTo(WebMvcLinkBuilder.methodOn(UsersController.class).getAllSTud()).withSelfRel();
	   
	    student.add(link);

	    return student;
	  }

	@GetMapping("/students")
	  public List<User> getAllSTud(){
		List<User> user=userRepo.findAll();
		return user;
	}
}
