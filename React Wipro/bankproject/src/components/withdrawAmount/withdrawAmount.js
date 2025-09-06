import axios from 'axios';
import React, {Component, useState} from 'react';

const Withdraw = () => {
  const[result,SetResult] = useState('');
 const [data, setData] = useState({
          accountNo : 0,
          withdrawAmount : 0,
      })
  
     const handleChange = event => {
        setData({
            ...data,[event.target.name] : event.target.value  
        })
    }

    const withdrawAccount = () => {
     axios.post("https://localhost:7182/withdraw/"+data.accountNo + "/"+data.withdrawAmount).then(resp => {
        //   alert(resp.data);
        SetResult(resp.data);
          console.log(resp.data);
        })
    }

      return (
        <div className="component-container">
            <div className="component-header">Withdraw Amount</div>
            
            <div className="form-group">
                <label>Account No : </label>
                <input type="number" name="accountNo" 
                    value={data.accountNo} onChange={handleChange} />
            </div>
            
            <div className="form-group">
                <label>Withdraw Amount : </label>
                <input type="number" name="withdrawAmount" 
                    value={data.withdrawAmount} onChange={handleChange} />
            </div>
 
            <input type="button" className="btn" value="Withdraw Amount" onClick={withdrawAccount} />
            
            {result && <div className="result-message">{result}</div>}
        </div>
      )

}

export default Withdraw;