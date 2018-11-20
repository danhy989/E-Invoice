import React,{Component} from 'react'
import {View,Text,TextInput,Button,Picker,TextStyle, ScrollView } from 'react-native'
import Css from '../Css/Css';
import firebase from 'react-native-firebase'

export default class GetCustomer extends Component{
    constructor(props){
        super(props);
        this.state = {
            name: '',
            address: '',
            phone: null,
            payment: 'COD',
            email: '',
            cusBankNo: null,
            cusBankName: 'Ngân hàng Á Châu',
            InvoiceName: 'Hóa đơn giá trị gia tăng',
            random: 0
        }
    }
   
    sendEInvoicing(){
       
        const totalPrice = this.props.navigation.state.params.totalPrice;
        
        let itemsData = this.props.navigation.state.params.data;
        let {name,address,phone,payment,email,cusBankNo,cusBankName,InvoiceName} = this.state;
            firebase.database().ref('hoadon').push({
                CusName: name,
                CusAddress: address,
                CusPhone: phone,
                Payment: payment,
                CusEmail: email,
                CusBankNo: cusBankNo,
                CusBankName: cusBankName,
                ComName: "UIT",
                ComPhone: 842837252002,
                ComAddress: "Khu phố 6, P.Linh Trung, Q.Thủ Đức, Tp.Hồ Chí Minh",
                InvoiceArisingDate: new Date().getDate()+'/'+new Date().getMonth()+'/'+new Date().getFullYear(),
                InvoiceName: InvoiceName,
                InvoiceSerialNo: 'UIT'+new Date().getTime(),
                InvoiceNo: new Date().getTime(),
                TotalPrice: totalPrice,
                itemsData
            }).then(this.props.navigation.navigate('finish',{checkSuccess:1}))
            .catch(error => this.props.navigation.navigate('finish',{checkSuccess:0,error:error}))
        //Nếu bằng 0 là lỗi , nếu bằng 1 là thành công
    
    }
    render(){
        //const data = this.props.navigation.state.params.data;
        const totalPrice = this.props.navigation.state.params.totalPrice;
        return(
            <View style={Css.containerGetCus}>
                <View style={Css.containerGetCusHeader}>
                    <Text style={{fontSize:20,fontWeight:'bold'}}>Nhập thông tin khách hàng</Text>
                </View>
                <View style={Css.containerGetCusBody}>
                    <ScrollView>
                        <TextInput
                            style={Css.getCusItemTextInPut} 
                            placeholder={'Tên khách hàng'} 
                            onChangeText={(value) => {this.setState({name:value})}}/>
                        <TextInput
                            style={Css.getCusItemTextInPut} 
                            placeholder={'Địa chỉ'} 
                            onChangeText={(value) => {this.setState({address:value})}}/>
                        <TextInput
                            style={Css.getCusItemTextInPut} 
                            placeholder={'Email'} 
                            keyboardType='email-address'
                            onChangeText={(value) => {this.setState({email:value})}}/>
                        <TextInput
                            style={Css.getCusItemTextInPut} 
                            placeholder={'Số điện thoại'} 
                            keyboardType='phone-pad'
                            onChangeText={(value) => {this.setState({phone:value})}}/>
                        
                        <Picker
                            selectedValue={this.state.InvoiceName}
                            style={{ height: 50, width: 250 }}
                            onValueChange={(itemValue, itemIndex) => this.setState({ InvoiceName: itemValue })}>
                            <Picker.Item label="Hóa đơn giá trị gia tăng" value="Hóa đơn giá trị gia tăng"/>
                            <Picker.Item label="Hóa đơn abcxyz" value="Hóa đơn abcxyz"/>
                        </Picker>
                
                        {this.state.payment==='Banking' && 
                        <TextInput
                            style={Css.getCusItemTextInPut} 
                            placeholder={'Số tài khoản'} 
                            keyboardType='phone-pad'
                            onChangeText={(value) => {this.setState({cusBankNo:value})}}/>
                        }
                        {this.state.payment==='Banking' && 
                        <Picker
                            selectedValue={this.state.cusBankName}
                            style={{ height: 50, width: 250 }}
                            onValueChange={(itemValue, itemIndex) => this.setState({cusBankName: itemValue})}>
                            <Picker.Item label="Ngân hàng Á Châu" value="ACB" />
                            <Picker.Item label="Ngân hàng Tiên Phong" value="TPBank"/>
                            <Picker.Item label="Ngân hàng Đông Á" value="DAF" />
                            <Picker.Item label="Ngân hàng Việt Nam Thịnh Vượng" value="VPBank" />
                            <Picker.Item label="Ngân hàng Sài Gòn Thương Tín" value="Sacombank" />
                            <Picker.Item label="Ngân hàng Xuất Nhập khẩu Việt Nam" value="Eximbank" />
                        </Picker>
                        }
                        <Picker
                            selectedValue={this.state.payment}
                            style={{ height: 50, width: 250 }}
                            onValueChange={(itemValue, itemIndex) => this.setState({payment: itemValue})}>
                            <Picker.Item label="Thanh toán khi nhận hàng" value="COD" />
                            <Picker.Item label="Thanh toán online" value="Banking" />
                        </Picker>
                    </ScrollView>
                </View>
                <View style={Css.viewTongTien}>
                    <Text style={Css.textTotalPrice}>Tổng tiền : {totalPrice} đồng</Text>
                </View>
                <View style={Css.containerChooseItemButton}>
                    <Button title='Gửi hóa đơn' color='#000000' onPress={()=>this.sendEInvoicing()}/>
                </View>
            </View>
        )
    }
}