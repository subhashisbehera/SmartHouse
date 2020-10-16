import React from 'react';

class TreeView extends React.Component {

    constructor(props) {
        super(props);
        this.state = { loading: true };
      }
    
   render() {
      return (
         <div>
     <ul>
      {
      this.props.nodes.map(node =>
      <li>
      <TreeViewNode  node = {node} onClick={()=> this.handleClick()}/>
      </li>  
      )}
      </ul>
     </div>
      );
   }
}
class TreeViewNode extends React.Component {
    constructor(props) {
        super(props);
        this.state = {loading: true };
      }

   handleClick()
    {
      alert("hello");
    }
   render() {
      return (
    <div>
      <ul>
      {
      this.props.nodes.map(node =>  
        <li>
      <TreeViewNodeContent  onClick={()=> this.handleClick()}/>
      </li>
      )}
      
      </ul>
        </div>   
      );
   }
}
class TreeViewNodeContent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {contents:[], loading: true };
      }
    handleClick()
    {
      alert("hello1");
    }
    render() {
       return (
        <li>
        {
        contents.map(room =>  
        <TreeViewNodeContent  onClick={()=> this.handleClick()}/>
        )}
        </li>
       );
    }
 }
export default App;