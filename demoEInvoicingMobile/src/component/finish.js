
import React, {Component} from 'react';
import {View,Text} from 'react-native'
import Css from '../Css/Css';
export default class Finish extends Component {
  render() {
      const checkSuccess = this.props.navigation.state.params.checkSuccess;
      const error = this.props.navigation.state.params.error;
    return (
      <View style={Css.container}>
          {checkSuccess===0 && <Text style={Css.textTotalPrice}>Gửi thất bại , quay trở lại để thử lại /n {error}</Text>}
        {checkSuccess===1 && <Text style={Css.textTotalPrice}>Gửi thành công đến firebase </Text>}
      </View>
    );
  }
}