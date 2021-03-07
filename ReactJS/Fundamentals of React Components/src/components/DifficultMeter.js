import {Component} from 'react';

class DifficultMeter extends Component{
    constructor(props){
        super(props)
        this.state = {
            difficultLevel: 0,
        }
        this.resetDifficultLevel = this.resetDifficultLevel.bind(this);
    }
    increaseLevel(){
        this.setState((oldState)=> ({difficultLevel: this.state.difficultLevel+1}));
    }
    decreaseLevel(){
        this.setState((prevState) => ({difficultLevel: prevState.difficultLevel - 1}));
    }
    resetDifficultLevel(){
        this.setState({difficultLevel: 0})
    }
    render(){
        return (
        <div className="difficult">
            <h2>Difficulty level: {this.state.difficultLevel}</h2>
            <button className="increase-level" onClick={(e) => this.setState({difficultLevel: this.state.difficultLevel + 1})}>+</button> 
            <button className="increase-level" onClick={(e)=> this.increaseLevel()}>Again +</button> 
            <button className="decrease-level" onClick={()=> this.setState((oldState)=> ({difficultLevel: oldState.difficultLevel -1}))}>-</button>
            <button className="decrease-level" onClick={this.decreaseLevel.bind(this)}>Again -</button>                   
            <button className="reset-level" onClick={this.resetDifficultLevel}>Reset Difficult Level</button>                         
        </div>);
    }
}

export default DifficultMeter;