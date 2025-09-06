import axios from 'axios';
import React, { useEffect, useState } from 'react';

const EmployShow = () => {

  const [employs, setEmployData] = useState([])
  const [loading, setLoading] = useState(true)

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get("https://localhost:7174/api/EmploysNew");
        console.log("API Response:", response.data);
        console.log("Response type:", typeof response.data);
        console.log("Is array:", Array.isArray(response.data));
        setEmployData(response.data);
        setLoading(false);
      } catch (error) {
        console.error("API fetch error:", error);
        setLoading(false);
      }
    };
    fetchData();
  }, []);

  console.log("Current employs state:", employs);
  console.log("Employs length:", employs.length);

  return (
    <div>
      <table border="3" align="center" style={{marginTop: '30px'}}>
        <thead>
          <tr>
            <th>Employ No</th>
            <th>Employ Name</th>
            <th>Gender</th>
            <th>Department</th>
            <th>Designation</th>
            <th>Basic</th>
          </tr>
        </thead>
        <tbody>
          {loading ? (
            <tr><td colSpan="6">Loading...</td></tr>
          ) : employs.length === 0 ? (
            <tr><td colSpan="6">No data found</td></tr>
          ) : (
            employs.map((item) =>
              <tr key={item.empno}>
                <td>{item.empno}</td>
                <td>{item.name}</td>
                <td>{item.gender}</td>
                <td>{item.dept}</td>
                <td>{item.desig}</td>
                <td>{item.basic}</td>
              </tr>
            )
          )}
        </tbody>
      </table>
    </div>
  )
}

export default EmployShow;