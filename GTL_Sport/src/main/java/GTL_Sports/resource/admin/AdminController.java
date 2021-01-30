package GTL_Sports.resource.admin;

import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;

@SpringBootApplication(scanBasePackages ={"/resource/admin"})
@Controller
public class AdminController {
	
	 
		@GetMapping("/adminView")
		public String Admin() {
			
			System.out.println("Inside Admin Controller");
			return "admindashboard";
		}
		
		@GetMapping("/datag")
			
		public String Admins() {
			
			System.out.println("Inside dff Controller");
			return "index";
		}
		

}
