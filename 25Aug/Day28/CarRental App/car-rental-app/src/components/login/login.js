import { useState } from "react";
import AuthService from "../../services/AuthService";

const Login = () => {

    // localStorage.clear();
    const[message,setMessage] = useState("")
    const [data,setState] = useState({
        username : '',
        password : '',
        result : ''
    })

    const handleChange = event => {
        setState({
          ...data,[event.target.name]:event.target.value
        })   
     }

    const authService = AuthService();

    const handleLogin = async () => {
      localStorage.clear();
        try {
        const token = await authService.login(data.username,data.password);
        setMessage("Token Generated...Access the Protected Resource");
        }
        catch(error) {
            alert("Login Failed");
        }
    }
         return(   
        <div className="container mt-5">
          <div className="row justify-content-center">
            <div className="col-md-6">
              <div className="card">
                <div className="card-body">
                  <h3 className="card-title text-center">Car Rental Login</h3>
                  <form>
                    <div className="mb-3">
                      <label className="form-label">User Name:</label>
                      <input type="text" name="username" value={data.username} 
                          onChange={handleChange} className="form-control" />
                    </div>
                    <div className="mb-3">
                      <label className="form-label">Password:</label>
                      <input type="password" name="password" value={data.password} 
                        onChange={handleChange} className="form-control" />
                    </div>
                    <div className="d-grid gap-2">
                      <input type="button" value="Login" onClick={handleLogin} className="btn btn-primary" />
                    </div>
                    {message && <div className="alert alert-success mt-3">{message}</div>}
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      )

}

export default Login;