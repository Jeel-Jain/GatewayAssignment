package GTL_Sports.resource.superadmin;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.util.StringUtils;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;

import GTL_Sports.domain.superadmin.Venue;
import GTL_Sports.domain.user.User;
import GTL_Sports.repository.superadmin.VenueRepository;
import GTL_Sports.repository.user.UserRepository;

import GTL_Sports.service.CustomUserDetails;

@Controller
public class SuperAdminController {
	
	@Autowired
    private UserRepository userRepo;
	@Autowired
	private VenueRepository venueRepo;
	@GetMapping("/approveAdmin")
	public String approveAdmin( @RequestParam(required=false,name="email") String email) {
		
        System.out.println(email);
        userRepo.approveAdmins(email);
       
		return "superadmindashboard";
	}
	@GetMapping("/rejectAdmin")
	public String rejectAdmin( @RequestParam(required=false,name="email") String email) {
		
        System.out.println(email);
        userRepo.rejectAdmins(email);
       
		return "superadmindashboard";
	}
	
	
	@GetMapping("/manageAdmins")
	public String listUsers(Model model) {
		
		org.springframework.security.core.Authentication auth = SecurityContextHolder.getContext().getAuthentication();
        CustomUserDetails userDetails = (CustomUserDetails)auth.getPrincipal();
        String Usrname=userDetails.getUsername();
        System.out.println(Usrname);
        
        User userData = userRepo.findByEmail(Usrname);
        System.out.println(userData.getRole());
     
       
    		List<User> listUsers = userRepo.findAll();
       	    model.addAttribute("listUsers", listUsers);
       	    	     
    
    	   return "showadminusers";
       }
	
		@GetMapping("/superadminView")
		public String superadminview(Model model) {
		
	   
    		
       	 return "superadmindashboard";
    
    	 
       }
		
		@GetMapping("/manageBookings")
		public String listBookings(Model model) {
			
			return "showbookings";
		}
		
		@GetMapping("/addVenues")
		public String addVenues(Model model) {
			model.addAttribute("venue",new Venue());
			
			return "venueForm";
		}
		@PostMapping("/createVenues")
		public String createVenues(Venue venue,@RequestParam("fileImage") MultipartFile fileImage) throws IOException {
			
			String filename=StringUtils.cleanPath(fileImage.getOriginalFilename());
			
		
			
			Venue v=new Venue();
			 v.setVenuename(venue.getVenuename());
			 v.setVenuelocation(venue.getVenuelocation());
			 v.setVenuedescription(venue.getVenuedescription());
			 v.setVenueprice(venue.getVenueprice());
			 v.setVenuetype(venue.getVenuetype());
			 v.setVenueimage(filename);
			 
			Venue savedVenue = venueRepo.save(v);
			String uploadDirectory= "./upload-img/"+savedVenue.getVenueid();
			Path uploadpath=Paths.get(uploadDirectory);
			if(!Files.exists(uploadpath))
			{
				Files.createDirectories(uploadpath);
			}
			
			InputStream inputStream=fileImage.getInputStream();
			Path filePath=uploadpath.resolve(filename);
			
			Files.copy(inputStream,filePath,StandardCopyOption.REPLACE_EXISTING);
			//System.out.println(venue.getVenuename());
			return "venueForm";
		}
		
		
			
}
