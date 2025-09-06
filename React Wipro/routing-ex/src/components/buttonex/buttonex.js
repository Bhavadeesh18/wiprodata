import React, {Component} from 'react';

const BottonEx = () => {

  const bhavadeesh = () => {
    alert("Bhavadeesh is a good boy");
  }
  const charan = () => {
    alert("Charan is a good boy");
  }
  
  const nandyala = () => {
    alert("Nandyala is a good family");
  }
  return(
    <div>
      <input type="button" value="Bhavadeesh" onClick={bhavadeesh} />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="Charan" onClick={charan}/>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
      <input type="button" value="Nandyala" onClick={nandyala} />
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
  )
}
export default BottonEx;