import axios from 'axios';
import React, {Component, useState} from 'react';

const EmploySearch = () => {
   const[employResult, SetEmployResult] = useState({})
    const[employId,SetEmployId] = useState(0) 

    const handleChange = event => {
        SetEmployId(event.target.value)
    }

    const show = () => {
      let eid = parseInt(employId);
      axios.get(`https://localhost:7174/api/EmploysNew/${eid}`)
        .then((response) => {
          SetEmployResult(response.data)
        })
        .catch((error) => {
          console.error('Error fetching employee:', error);
          alert('Employee not found or error occurred');
        })
    }

    return(
      <div>
         <label>
                Employ Id : </label>
            <input type="number" name="employId" 
                value={employId} onChange={handleChange} /> <br/>
            <input type="button" value="Show" onClick={show} />
            <hr/>
            Employ No : <b>{employResult.empno}</b> <br/> 
            Name : <b>{employResult.name}</b> <br/>
            Gender : <b>{employResult.gender}</b> <br/>
            Department : <b>{employResult.dept}</b> <br/>
            Designation : <b>{employResult.desig}</b> <br/>
            Basic : <b>{employResult.basic}</b>
      </div>
    )
  
}

export default EmploySearch;