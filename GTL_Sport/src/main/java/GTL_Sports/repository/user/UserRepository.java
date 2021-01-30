package GTL_Sports.repository.user;
import java.util.List;
import java.util.Optional;

import org.springframework.data.domain.Example;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

import GTL_Sports.domain.user.*;

public interface UserRepository extends JpaRepository<User, Long> {
//    @Query("SELECT u FROM users u WHERE u.email = ?1")
//    public User findByEmail(String email);
     
	 @Query("SELECT u FROM User u WHERE u.email = ?1")
	    public User findByEmail(String email);
	 
	 @Transactional 
	 @Modifying(clearAutomatically = true)
	 @Query("update User u set u.isapprove = 1 where u.email =:email")
	 void approveAdmins(@Param("email") String email);
	 
	 
	 @Transactional 
	 @Modifying(clearAutomatically = true)
	 @Query("update User u set u.isapprove = 0 where u.email =:email")
	 void rejectAdmins(@Param("email") String email);
	 
	 
	 
	
}