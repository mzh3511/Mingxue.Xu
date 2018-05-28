let app = getApp();

Page({
  data: {
    touch_start: '',
    touch_end: '',
    arlist: [],
    lylist: [],
    lylist1: [],
    shareObj: {
      share: []
    },
    offset: 0,
    userInfo: {},
    sort: [{
      txt: '发现',
      type: 1
    }, {
      txt: '寻找',
      type: 2
    }, {
      txt: '点我',
      type: 0
    }],
    curSort: 5,
    //显示首页滚动图片
    // banners: [{
    //   url: '../main/Main',
    //   img: '../../../assets/images/timg-7.jpeg'
    // }, {
    //   url: '../main/Main',
    //   img: '../../../assets/images/timg-8.jpeg'
    // }],
    mine: [{
      url: '../../b/i/i?tab=time&from=myc',
      img: '../../../assets/images/icons/share.png',
      word: '我的评论'
    }]
  },
  sortBallTap1() {
    var that = this;
    var pid = '1';
    wx.navigateTo({
      url: '../index2/index2?id=' + pid
    })
  },
  sortBallTap2() {
    var that = this;
    var pid = '2';
    wx.navigateTo({
      url: '../index2/index2?id=' + pid
    })
  },
  load: function () {
    var list = wx.getStorageSync('pet_list')
    var list1 = wx.getStorageSync('petly_list')
    this.setData({ arlist: list, lylist: list1, lylist1: list1 })
  },
  onLoad() {
    app.register('bz', app);
    this.setData({
      showFinger: !app.local.getSync('rt_finger_showed')
    });
    app.getWxUserInfo(res => {
      this.setData({
        userInfo: res
      });
    });
    //this.getData();
    this.load();
  },
  onShow() {
    if (app.cache.back_index_show_mine) {
      this.showMine();
      app.removeCache('back_index_show_mine');
    }
  },
  // getData(sort) {
  //   !this.data.isLoading && this.setData({
  //     isLoading: true
  //   });
  //   app.httpService.getIndexArticles(this.data.offset)
  //     .then(data => {
  //       app.util.getSharesCb(this, data);
  //     }, () => {
  //       this.setData({
  //         isNetError: true
  //       });
  //     });
  // }
  // ,
  nextLoad(sort) {
    this.data.hasNextPage = false;
    app.httpService.getIndexArticles(this.data.offset)
      .then(data => {
        app.util.nextSharesCb(this, data);
      }, () => {
        this.setData({
          hasNextPage: false
        });
      });
  },
  onShow: function () {
    this.load();
  }
  // ,
  // onShareAppMessage() {
  //     let title = `${(app._user && app._user.nickName || 'GameGuy')} 邀你加入GG，我也在，所以更懂你`;
  //     return app.util.getShareParams(`/pages/b/z/z`, title);
  // }
  , editAddress: function (event) {
    let that = this;
    //触摸时间距离页面打开的毫秒数  
    var touchTime = that.data.touch_end - that.data.touch_start;
    //如果按下时间大于350为长按  
    if (touchTime > 350) {
      wx.showModal({
        title: '提示',
        content: '是否删除该地址',
        success: function (res) {
          if (res.confirm) {
            var Index = event.currentTarget.dataset.id;
            for (let i = 0; i < that.data.arlist.length; i++) {
              if (that.data.arlist[i].id == Index) {
                for (let j = 0; j < that.data.lylist.length; j++) {
                  if (that.data.lylist[j].personid != Index) {
                    var inti = this.data.lylist1.length;
                    var lylist1 = "lylist1[" + inti + "]"
                    this.setData({
                      [lylist1]: that.data.lylist[j]
                    })
                  }
                }
                that.data.arlist.splice(i, 1);
                that.save();
              }
            }
          }
        }
      })
    } else {
      var pageid = event.currentTarget.dataset.id;
      wx.navigateTo({
        url: '../detailed2/detailed2?id=' + pageid,
        success: function (res) {

          // success

          console.log('onBtnClick success() res:' + pageid);

        },

        fail: function () {

          // fail

          console.log('onBtnClick fail() !!!');

        },

        complete: function () {

          console.log('onBtnClick complete() !!!');

          // complete

        }

      })
    }
  },
  save: function () {
    wx.setStorageSync('pet_list', this.data.arlist)
    wx.setStorageSync('petly_list', this.data.lylist1)
    this.load();
  },
  //按下事件开始  
  mytouchstart: function (e) {
    let that = this;
    that.setData({
      touch_start: e.timeStamp
    })
  },
  //按下事件结束  
  mytouchend: function (e) {
    let that = this;
    that.setData({
      touch_end: e.timeStamp
    })
  },
});