import {Component} from 'react';
import DifficultMeter from './DifficultMeter';

class Sport extends Component{
    constructor(props){
        super(props)
        this.props = props;
    }
    render(){
        return (
            <div className='sport-header'>
                <h1>My favourite sport is {this.props.sport}</h1>
                <DifficultMeter difficultLevel={this.props.difficultLevel}/>
            </div>
        );
    }
}

export default Sport;