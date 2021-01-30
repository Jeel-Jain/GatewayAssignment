package GTL_Sports.domain.superadmin;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;



@Entity
@Table(name="venues")

public class Venue {
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
private Long venueid;
	@Column(nullable = false,length=45)
	private String venuename;
	private String venuelocation;
	private String venuedescription;
	private String venueimage;
	private String venueprice;
	private String venuetype;
	public String getVenuetype() {
		return venuetype;
	}
	public void setVenuetype(String venuetype) {
		this.venuetype = venuetype;
	}
	public Long getVenueid() {
		return venueid;
	}
	public void setVenueid(Long venueid) {
		this.venueid = venueid;
	}
	public String getVenuename() {
		return venuename;
	}
	public void setVenuename(String venuename) {
		this.venuename = venuename;
	}
	public String getVenuelocation() {
		return venuelocation;
	}
	public void setVenuelocation(String venuelocation) {
		this.venuelocation = venuelocation;
	}
	public String getVenuedescription() {
		return venuedescription;
	}
	public void setVenuedescription(String venuedescription) {
		this.venuedescription = venuedescription;
	}
	public String getVenueimage() {
		return venueimage;
	}
	public void setVenueimage(String venueimage) {
		this.venueimage = venueimage;
	}
	public String getVenueprice() {
		return venueprice;
	}
	public void setVenueprice(String venueprice) {
		this.venueprice = venueprice;
	}
	


}

