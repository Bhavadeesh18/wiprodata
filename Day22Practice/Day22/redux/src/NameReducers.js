const initialState = {
    sname : ''
}

const NameReducer = (state = initialState, action) => {
    switch(action.type) {
        case 'BABLU' :
            return {...state,sname:'Hi I am Bablu'};
        case 'BHAVADEESH' : 
            return {...state,sname:'Hi I am Bhavadeesh'};
        case 'NBR' : 
            return {...state,sname:'HI I am NBR'}
        default : 
            return state;
    }
}

export default NameReducer;