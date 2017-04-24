import React, {Component} from 'react'
import CopyRight from 'CopyRight'
import ActivityTool from 'ActivityTool'
var Footer = (props) =>{

    return(
		<div className="page-footer">
			<div className="row">
                <CopyRight/>
                <ActivityTool/>
			</div>
		</div>
    );

};
export default ActivityTool;