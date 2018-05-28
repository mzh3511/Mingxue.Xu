// pages/detailed/detailed.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    Person: {
      id: 0,
      FilePaths: '',
      input: '',
      CreateTime: '',
      isLike: 0
    },
    Py: {
      personid: 0,
      input: '',
      user: '',
      time: ''
    },
    lylist: [],
    input: '',
    userInfo: ''
  },
  addTodoHandle: function (event) {
    if (!this.data.input || !this.data.input.trim()) return
    var myDate = new Date();
    var pyid = 'Py.personid';
    var pyinput = 'Py.input';
    var pyuser = 'Py.user';
    var pytime = 'Py.time';
    this.setData({
      [pyid]: event.currentTarget.dataset.id,
      [pyinput]: this.data.input,
      [pyuser]: this.data.userInfo,
      [pytime]: myDate.getFullYear() + '年' + (myDate.getMonth() + 1) + '月' + myDate.getDate() + '日',
    })
    console.log(this.data.Py);
    this.save()
    this.setData({
      input: ''
    })
  },
  FindPerson: function () {
    var plike = 'Person.isLike';
    this.setData({
      [plike]: 1
    })
    var updatelist = wx.getStorageSync('pet_list')
    for (let i = 0; i < updatelist.length; i++) {
      if (updatelist[i].id == this.data.Person.id) {
        updatelist[i] = this.data.Person;
      }
    }
    wx.setStorageSync('pet_list', updatelist)

  },
  save: function () {
    var py = this.data.Py;
    var inti = this.data.lylist.length;
    var lylist = "lylist[" + inti + "]"
    this.setData({
      [lylist]: py
    })
    wx.setStorageSync('petly_list', this.data.lylist)
  },
  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    let that = this;
    wx.getUserInfo({
      success: function (res) {
        that.setData({
          userInfo: res.userInfo.nickName
        })
      }
    })
    var list = wx.getStorageSync('pet_list')
    var pylist = wx.getStorageSync('petly_list')
    for (let i = 0; i < list.length; i++) {
      if (list[i].id == options.id) {

        that.setData({ Person: list[i] })
      }
    }

    for (let j = 0; j < pylist.length; j++) {
      if (pylist[j].personid == options.id) {
        //this.setData({ lylist: pylist })
        var py = pylist[j];
        var inti = this.data.lylist.length;
        var lylist = "lylist[" + inti + "]"
        this.setData({
          [lylist]: py
        })
        console.log(this.data.lylist);
      }
    }
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  },
  onBtnClick: function () {
    //wx.navigateBack();  
  },

  inputChangeHandle: function (e) {
    this.setData({ input: e.detail.value })
  }
})