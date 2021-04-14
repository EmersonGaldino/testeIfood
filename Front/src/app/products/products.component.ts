import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {ProductsService} from './products.service';
import {FormBuilder, FormGroup, Validator} from '@angular/forms';
import {Product} from './Product';
import {MatPaginator} from '@angular/material/paginator';
import {MatSnackBar} from '@angular/material/snack-bar';

export interface MessageLoading {
  message: string;
  action: string;
}

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})

export class ProductsComponent implements OnInit {

  displayColumns: string[] = ['id', 'Descrição', 'Valor', 'Imagem', 'Ativo'];
  // @ts-ignore
  products: Product[];
  // @ts-ignore
  product: Product ;
  // @ts-ignore
  edit: boolean = false;

  messageLoading: MessageLoading = {
    action: 'success',
    message: 'Produtos carregados com sucesso'
  };
  createForm = this.formBuilder.group({
    description: '',
    value: null,
    image: '',
    id: 0,
    active: true
  });


  constructor(
    private fb: FormBuilder,
    private service: ProductsService,
    private formBuilder: FormBuilder,
    private snackbar: MatSnackBar
  ) {
  }

  ngOnInit(): void {
    this.service.list().subscribe(data => this.products = data);
  }

  onLoad(): void {
    this.service.list().subscribe(data => this.products = data);
  }

  // tslint:disable-next-line:typedef
  loadOne(product: number): void {
     this.service.getOne(product).subscribe(data => this.setValues(data));
  }

  setValues(item: any): void{
    let { data } = item;
    this.edit = true;
    this.createForm.patchValue({
      id: data.id,
      description: data.description,
      value: data.value,
      image: data.image,
      active: true
    });
  }

  // tslint:disable-next-line:typedef
  delete(product: number): void {
    this.service.delete(product).subscribe(() => {
      this.onLoad();
    });
    this.openSnackBar('Produto deletado com sucesso', 'Delete');
  }

  openSnackBar(message: string, action: string): void {
    this.snackbar.open(message, action, {
      duration: 2000,
    });
  }

  onSubmit(edit: boolean): void {
    if (this.createForm.valid) {
      if (edit){
        this.service.update(this.createForm.value).subscribe(
          success => {
            this.onLoad();
            this.openSnackBar('Produto alterado com sucesso', 'Alter');
          },
          error => this.openSnackBar('Não foi possivel alterar o produto.', 'Alter')
        );

      }else{
        this.service.create(this.createForm.value).subscribe(
          success => {
            this.onLoad();
            this.openSnackBar('Produto criado com sucesso', 'Create');
          },
          error => this.openSnackBar('Não foi possivel criar o produto', 'Error')
        );
      }
      this.edit = false;
      this.createForm.reset();
    }
  }
}
