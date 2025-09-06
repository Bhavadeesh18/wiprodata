import axios from 'axios';
import React, {Component, useEffect, useState} from 'react';

const UserShow = () => {
  
  const [users,setUserData] = useState([])

  useEffect(() => {
    const fetchData = async () => {
      const response = await
        axios.get("https://jsonplaceholder.typicode.com/users");
        setUserData(response.data)
    }
    fetchData();
  },[])    
  return(
    <div>
      <table border="3" align='center'>
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>UserName</th>
            <th>Email</th>
            <th>Phone</th>
            <th>Website</th>
          </tr>
        </thead>
        <tbody>
          {users.map((item) => 
            <tr key={item.id}>
              <td>{item.id}</td>
              <td>{item.name}</td>
              <td>{item.username}</td>
              <td>{item.email}</td>
              <td>{item.phone}</td>
              <td>{item.website}</td>
            </tr>
          )}
        </tbody>
      </table>
    </div>
  )
}

export default UserShow;