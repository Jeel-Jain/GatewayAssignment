package GTL_Sports.repository;
import java.util.List;
import java.util.Optional;

import org.springframework.data.domain.Example;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;

import GTL_Sports.domain.User;

public interface UserRepository extends JpaRepository<User, Long> {
//    @Query("SELECT u FROM users u WHERE u.email = ?1")
//    public User findByEmail(String email);
     
	 @Query("SELECT u FROM User u WHERE u.email = ?1")
	    public User findByEmail(String email);
}