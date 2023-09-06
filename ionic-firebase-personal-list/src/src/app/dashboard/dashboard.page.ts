import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../shared/authentication-service';
import { FireService, kayitBilgi } from '../fire.service';
import { AlertController,ToastController } from '@ionic/angular';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.page.html',
  styleUrls: ['./dashboard.page.scss'],
})
export class DashboardPage implements OnInit {
  kayitlar:kayitBilgi[]  = [];

  constructor(public authService: AuthenticationService, private fireService:FireService,private alertController:AlertController,private toastController:ToastController) {
   
    this.fireService.kayitListele().subscribe(sonuc => {this.kayitlar = sonuc; console.log(this.kayitlar)})
 
  }

  async presentAlert() {
    const alert = await this.alertController.create({
      header: 'Personel Ekle',
      inputs: [
        {
          name: 'ad',
          placeholder: 'Personel adı',
          type: 'text'
        },
        {
          name: 'ceptel',
          type:'text',
          placeholder:'Telefon no',
        }
      ],
      buttons: [
        {
          text:'Vazgeç',
          role:'Cancel'
        },
        {
          text:'Kaydet',
          handler: res => {
         
           this.fireService.yeniKayit(res);
          }
        }
      ],
    });

    await alert.present();
  }


  async deleteItem(data){
   this.fireService.kayitSil(data); //direk id gönderdim
   await this.toastController.create({
   duration: 2000
   });    
   }

   async updateItem(data){
    const alert = await this.alertController.create({
      header: 'Personel Güncelle',
      inputs: [
        {
          name: 'ad',
          placeholder: 'Personel adı',
          type: 'text',
          value : data.ad //datalar dolu gelsin
        },
        {
          name: 'ceptel',
          type:'text',
          placeholder:'Telefon no',
          value : data.ceptel //datalar dolu gelsin
        },
      ],
      buttons: [
        {
          text:'Vazgeç',
          role:'Cancel'
        },
        {
          text:'Kaydet',
          handler: res => {
            res.id = data.id; //id boş gelmemesi için almam lazım
           this.fireService.kayitGuncelle(res);
          }
        }
      ],
    });

    await alert.present();
}

ngOnInit() {}

}
