package GTL_Sports.resource.user;

import java.util.List;

import org.apache.tomcat.util.net.openssl.ciphers.Authentication;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.servlet.ViewResolver;
import org.springframework.web.servlet.view.InternalResourceViewResolver;

import GTL_Sports.domain.user.*;
import GTL_Sports.repository.user.*;
import GTL_Sports.service.CustomUserDetails;

@Controller
public class UserController{
	
	@Autowired
    private UserRepository userRepo;
	@GetMapping("")
	public String viewHomePage() {
		
		return "index";
		
	}
	
//	  @Bean
//	    public ViewResolver getViewResolver() {
//	        InternalResourceViewResolver resolver = new InternalResourceViewResolver();
//	        resolver.setPrefix("templates/");
//	        resolver.setSuffix(".html");
//	        return resolver;
//	    }
	@GetMapping("/register")
	public String showSignUpPage(Model model ) {
		model.addAttribute("user",new User());
		return "signup_form";
	}
	@PostMapping("/process_register")
	public String processRegister(User user) {
	    
		BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();
		String encodedPassword = passwordEncoder.encode(user.getPassword());
		    
		     
	
	    user.setFname(user.getFname());
	    user.setLname(user.getLname());
	    user.setEmail(user.getEmail());
	    user.setRole("Admin");
	    user.setPassword(encodedPassword);
	    user.setContact(user.getContact());
	    user.setIsapprove(0);
	   
	    userRepo.save(user);
	     
	    return "register_success";
	}
	
	@GetMapping("/usersdashboard")
	public String userDash(Model model) {
	
	    return "userdashboard";
	}
	
	@GetMapping("/users")
	public String redirectToAdmin(Model model) {
		
		org.springframework.security.core.Authentication auth = SecurityContextHolder.getContext().getAuthentication();
        CustomUserDetails userDetails = (CustomUserDetails)auth.getPrincipal();
        String Usrname=userDetails.getUsername();
        System.out.println(Usrname);
        
        User userData = userRepo.findByEmail(Usrname);
        System.out.println(userData.getRole());
     
       if(userData.getRole().equals("SuperAdmin"))
       {
    	  
    	   return "redirect:superadminView";
       	    	     
       	  
       }
       else if(userData.getIsapprove()==1 && userData.getRole().equals("Admin"))
       {
    	  return "redirect:adminView";
    
       }
       else
       {
    	   return "index";
       }
       
      
	   
	}

}
