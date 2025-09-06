const AuthHeader = () => {
    const token = localStorage.getItem("token");
    if (token) {
       return { 'X-JWT-Token': token }; // for ASP.NET Core back-end
    } else {
      return {};
    }
}
export default AuthHeader