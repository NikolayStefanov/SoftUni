import Sport from './Sport';
function SportsList(props){


    return (
        <ul className="sports">
            {props.sports.map(s=> <Sport sport={s.sport}/>)}
        </ul>
    )

}

export default SportsList;